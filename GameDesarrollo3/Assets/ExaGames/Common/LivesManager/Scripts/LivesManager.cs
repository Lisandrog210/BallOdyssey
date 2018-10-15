using System;
using ExaGames.Common.TimeBasedLifeSystem.DataPersistance;
using ExaGames.Common.TimeBasedLifeSystem.LocalNotifications;
using UnityEngine;
using UnityEngine.Events;

namespace ExaGames.Common.TimeBasedLifeSystem {
	/// <summary>
	/// Lives system manager by ExaGames.
	/// </summary>
	/// <coauthor>Ed Casillas</coauthor>
	/// <coauthor>Nico Michelini</coauthor>
	public class LivesManager : MonoBehaviour {
		#region Serializables
		[Serializable]
		public class _BaseSettings {
			/// <summary>
			/// Maximum number of lives by default for all players.
			/// Additional life slots can be added for the player with <see cref="AddLifeSlots"/>
			/// </summary>
			[Tooltip("Maximum number of lives by default for all players.")]
			public int DefaultMaxLives = 5;
			/// <summary>
			/// Time to recover one life in minutes.
			/// </summary>
			[Tooltip("Time to recover one life in minutes.")]
			public double MinutesToRecover = 30D;
		}

		[Serializable]
		public class _CustomTexts {
			[Tooltip("Text to be used in the time observer when lives are full.")]
			public string FullLives = "Full";
			[Tooltip("Text to be used in the life observer while the player has infinite lives.")]
			public string Infinite = "∞";
		}

		[Serializable]
		public class _DebugOptions {
			/// <summary>
			/// Set this value to true to reset the LivesManager preferences when playing in the Editor.
			/// </summary>
			[Tooltip("Check this field to reset the LivesManager preferences when playing in the Editor.")]
			public bool ResetPlayerPrefsOnPlay = false;
			/// <summary>
			/// When set to true, enables advanced debugging in the inspector.
			/// </summary>
			[Tooltip("When checked, enables advanced debugging in the inspector.")]
			public bool InspectorDebugging = true;
		}

		[Serializable]
		public class _AdvancedSettings {
			/// <summary>
			/// Identifier for this <see cref="LivesManager"/> instance.
			/// </summary>
			[Tooltip("(Optional) Identifier for this LivesManager. Leave blank if you intend to have a single LivesManager.")]
			public string Id;
			/// <summary>
			/// Texts to be used in the time and life observers in special cases.
			/// </summary>
			[Tooltip("Texts to be used in the time and life observers in special cases.")]
			public _CustomTexts CustomTexts;
			/// <summary>
			/// When this value is true and the remaining time is greater than one hour, shows the remaining time as >Xhrs.
			/// </summary>
			[Tooltip("When this box is checked and the remaining time is greater than one hour, shows the remaining time as >Xhrs.")]
			public bool SimpleHourFormat = false;
			/// <summary>
			/// When this value is true, the time to recover will start running only when the number of lives has reached zero; then, when the time to recover reaches zero, it will fill
			/// lives again.
			/// </summary>
			[Tooltip("(Experimental) When this value is true, the time to recover will start running only when the number of lives has reached zero; then, when the time to recover reaches zero, it will fill lives again.")]
			public bool AllOrNothing = false;
			/// <summary>
			/// Options for debugging.
			/// </summary>
			public _DebugOptions DebugOptions;
		}

		[Serializable]
		public class IntEvent : UnityEvent<int> { }

		[Serializable]
		public class StringEvent : UnityEvent<string> { }
		#endregion

		#region Inspector fields
		/// <summary>
		/// Base settings for this LivesManager.
		/// </summary>
		[Tooltip("Base settings for this lives manager.")]
		public _BaseSettings BaseSettings;

		/// <summary>
		/// Advanced settings for this LivesManager.
		/// </summary>
		[Tooltip("Advanced settings for this lives manager.")]
		public _AdvancedSettings AdvancedSettings;

		/// <summary>
		/// Local notification settings set in the Inspector.
		/// </summary>
		public NotificationSettingsStruct LocalNotificationSettings;

		/// <summary>
		/// Event to be called when the number of lives has changed.
		/// </summary>
		[Header("Event to be called when the number of lives has changed.")]
		public LivesChangedEvent OnLivesChanged;
		/// <summary>
		/// Event to be called when the time to recover one life has changed.
		/// </summary>
		[Header("Event to be called when the time to recover one life has changed.")]
		public StringEvent OnRecoveryTimeChanged;
		/// <summary>
		/// Event to be called when the maximum number of lives has changed.
		/// </summary>
		[Header("Event to be called when the maximum number of lives has changed.")]
		public IntEvent OnMaxLivesChanged;
		#endregion

		#region Private Fields
		/// <summary>
		/// Data provider for persistant data.
		/// </summary>
		private readonly ILivesManagerDataRepository repository = new LivesManagerDataPlayerPrefsRepository();
		/// <summary>
		/// Contains the data that need to be persisted for this instance.
		/// </summary>
		private LivesManagerData data = new LivesManagerData();

		/// <summary>
		/// Object to schedule device notifications.
		/// </summary>
		private AbstractNotificationScheduler notificationScheduler;

		/// <summary>
		/// Time remaining until the next life in seconds.
		/// </summary>
		private double secondsToNextLife;
		/// <summary>
		/// Time remaining with infinite lives.
		/// </summary>
		private double remainingSecondsWithInfiniteLives;
		/// <summary>
		/// Specifies whether the timer to next life should be calculated.
		/// </summary>
		private bool calculateSteps;
		/// <summary>
		/// Specifies whether the application was paused and should reinit the timer at OnApplicationPause.
		/// </summary>
		/// <remarks>
		/// The use of this field prevents a bug in Unity Editor where the OnApplicationPause is sometimes called
		/// before Start or Awake methods, just after pressing the play button in the editor.
		/// </remarks>
		private bool applicationWasPaused;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the current number of available lives.
		/// </summary>
		/// <value>Current number of available lives.</value>
		public int Lives { get { return data.Lives.Value; } }
		
		/// <summary>
		/// Gets the maximum number of lives for the current player.
		/// </summary>
		/// <value>Maximum number of lives for the current player.</value>
		public int MaxLives {
			get { return data.MaxLives.Value; }
			private set {
				data.MaxLives = value;
				OnMaxLivesChanged.Invoke(data.MaxLives.Value);
			}
		}
		
		/// <summary>
		/// Gets the text that should be shown as the number of lives remaining: either a number or an infinite symbol.
		/// </summary>
		/// <value>Text that should be shown as the number of lives remaining: either a number or an infinite symbol.</value>
		public string LivesText { get { return HasInfiniteLives ? AdvancedSettings.CustomTexts.Infinite : data.Lives.ToString(); } }
		
		/// <summary>
		/// Gets the time remaining until the next life is restored, in seconds.
		/// </summary>
		/// <value>Time remaining until the next life in seconds..</value>
		public double SecondsToNextLife { get { return secondsToNextLife; } }
		
		/// <summary>
		/// Convinience property that returns <c>true</c> when there are lives available.
		/// </summary>
		/// <value><c>true</c> if this instance can play; otherwise, <c>false</c>.</value>
		public bool CanPlay{ get { return data.Lives > 0; } }
		
		/// <summary>
		/// Gets a value indicating whether lives are at their maximum number.
		/// </summary>
		/// <value><c>true</c> if lives are at their max; otherwise, <c>false</c>.</value>
		public bool HasMaxLives { get { return (data.Lives >= MaxLives); } }
		
		/// <summary>
		/// Gets a value indicating whether infinite lives mode is active at the moment.
		/// </summary>
		/// <value><c>true</c> if this player has infinite lives; otherwise, <c>false</c>.</value>
		public bool HasInfiniteLives{ get { return remainingSecondsWithInfiniteLives > 0D; } }
		
		/// <summary>
		/// Gets the remaining time for next life (or for infinite mode to expire) formatted as mm:ss
		/// </summary>
		/// <value>Remaining time for next life formatted as mm:ss</value>
		/// <remarks>
		/// When lives are full and <c>CustomFullLivesText</c> is set, 
		/// the value of <c>CustomFullLivesText</c> is returned.
		/// This value is also affected by the <c>SimpleHourFormat</c> when the remaining time is greater than one hour;
		/// When <c>SimpleHourFormat</c> = <c>true</c>, the string is formatted as "> X hrs",
		/// when <c>SimpleHourFormat</c> = <c>false</c>, the string is formatted as hh:mm:ss
		/// </remarks>
		public string RemainingTimeString {
			get { 
				if(!HasInfiniteLives && HasMaxLives && !string.IsNullOrEmpty(AdvancedSettings.CustomTexts.FullLives)) {
					return AdvancedSettings.CustomTexts.FullLives;
				}
				TimeSpan timerToShow = RemainingTimeSpan;
				if(timerToShow.TotalHours > 1D) {
					if(AdvancedSettings.SimpleHourFormat) {
						int hoursLeft = Mathf.RoundToInt((float)timerToShow.TotalHours);
						return string.Format(">{0} hr{1}", hoursLeft, hoursLeft > 1 ? string.Empty : "");
					}
					return timerToShow.ToString().Substring(0, 8);
				}
				return timerToShow.ToString().Substring(3, 5);
			}
		}

		/// <summary>
		/// Gets the remaining time for next life, or for infinite mode to expire.
		/// </summary>
		public TimeSpan RemainingTimeSpan {
			get {
				return TimeSpan.FromSeconds(HasInfiniteLives ? remainingSecondsWithInfiniteLives : secondsToNextLife);
			}
		}
		
		/// <summary>
		/// Gets the total number of seconds remaining to replenish all lives.
		/// </summary>
		/// <value>The seconds to full lives.</value>
		public double SecondsToFullLives { get { return secondsToNextLife + ((MaxLives - data.Lives.Value - 1) * (BaseSettings.MinutesToRecover * 60)); } }
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LivesManager"/> class.
		/// </summary>
		public LivesManager() { calculateSteps = false; }
		
		#region Unity Behaviour Methods
		/// <summary>
		/// Initializes lives, max lives and recoveryStartTime from local persistance if player is comming back, or
		/// with full lives and default max lives if this is the first time she plays.
		/// </summary>
		private void Awake() {
			if(!validateUniqueInstance()) {
				Debug.LogErrorFormat("More than one LivesManager with Id \"{0}\" found in scene.", AdvancedSettings.Id);
				return;
			}
#if !UNITY_EDITOR
			// This line ensures that preferences won't be reset by error with the game published.
			AdvancedSettings.DebugOptions.ResetPlayerPrefsOnPlay = false;
#endif
			notificationScheduler = NotificationSchedulerFactory.CreateScheduler(LocalNotificationSettings);

			if(AdvancedSettings.DebugOptions.ResetPlayerPrefsOnPlay) { ResetPlayerPrefs();
			} else { retrievePlayerPrefs(); }
		}
		
		/// <summary>
		/// On start, calculates the number of lives that must be recovered and the remaining seconds for the next life.
		/// </summary>
		private void Start() { initTimer(); }
		
		/// <summary>
		/// Every frame calculates the next step of the timer for the next life.
		/// </summary>
		private void Update() {
			if(calculateSteps) {
				stepRecoveryTime();
			}
		}
		
		/// <summary>
		/// When paused, saves the recovery start time to use it when unpaused.
		/// </summary>
		/// <param name="pauseStatus">If set to <c>true</c> pause status.</param>
		private void OnApplicationPause(bool pauseStatus) {
			if(pauseStatus) {
				applicationWasPaused = true;
				calculateSteps = false;
			} else if(applicationWasPaused) {
				applicationWasPaused = false;
				initTimer();
			}
		}
		
		/// <summary>
		/// On destroy, saves the recovery start time to use it next time the Lives Manager is available 
		/// (on application restart, for example).
		/// </summary>
		private void OnDestroy() { savePlayerPrefs(); }
		#endregion
		
		#region Public Methods
		/// <summary>
		/// Consumes one life if available, and starts counting time for recovery.
		/// </summary>
		/// <returns><c>true</c>, if life was consumed, <c>false</c> otherwise.</returns>
		public bool ConsumeLife() {
			if(HasInfiniteLives) return true;
			if (data.Lives <= 0) return false;

			var scheduleNotification = false;

			if (AdvancedSettings.AllOrNothing) {
				if (data.Lives == 1) {
					data.RecoveryStartTime = DateTime.Now;
					resetSecondsToNextLife();
					scheduleNotification = true;
				}
			}
			else {
				if (HasMaxLives) { // If lives were full, starts counting time for recovery.
					data.RecoveryStartTime = DateTime.Now;
					resetSecondsToNextLife();
				}
				scheduleNotification = true;
			}
			
			data.Lives--;
			notifyLivesChanged();
			savePlayerPrefs();
			if(scheduleNotification) notificationScheduler.ScheduleNotification(SecondsToFullLives);

			return true;
		}
		
		/// <summary>
		/// Grants one life to the player.
		/// </summary>
		public void GiveOneLife() { GiveLives(1); }

		/// <summary>
		/// Grants the amount of lives specified by <paramref name="numLives"/> to the player.
		/// </summary>
		/// <param name="numLives">Amout of lives to give.</param>
		public void GiveLives(int numLives) {
			if (!HasMaxLives && !HasInfiniteLives) {
				if (data.Lives + numLives >= MaxLives) {
					FillLives();
					return;
				}

				data.Lives += numLives;
				savePlayerPrefs();
				notifyAll();
			}
		}
		
		/// <summary>
		/// Restores all lives to its maximum.
		/// </summary>
		public void FillLives() {
			if(!HasInfiniteLives) {
				data.Lives = MaxLives;
				setSecondsToNextLifeToZero();
				notifyAll();
			}
		}
		
		/// <summary>
		/// Increases the maximum amount of lives by the specified <paramref name="quantity"/>, optionally restoring lives to the new maximum when <paramref name="fillLives"/> is set to <c>true</c>.
		/// </summary>
		/// <param name="quantity">The quantity of slots to add.</param>
		/// <param name="fillLives">If set to <c>true</c> fills lives to the new maximum.</param>
		public void AddLifeSlots(int quantity, bool fillLives = false) {
			if(HasMaxLives && !HasInfiniteLives) {
				data.RecoveryStartTime = DateTime.Now;
				resetSecondsToNextLife();
			}
			MaxLives += quantity;
			if(fillLives) { FillLives(); }
			else { savePlayerPrefs(); }
			initTimer();
		}
		
		/// <summary>
		/// Gives infinite lives for the specified amount of <paramref name="minutes"/>.
		/// </summary>
		/// <param name="minutes">The amount of minutes to grant infinite lives.</param>
		public void GiveInifinite(int minutes) {
			if(minutes <= 0) { return; }
			if(!HasInfiniteLives) {
				FillLives();
				data.InfiniteLivesStartTime = DateTime.Now;
			}
			data.InfiniteLivesMinutes += minutes;
			remainingSecondsWithInfiniteLives += minutes * 60;
			savePlayerPrefs();
			notifyAll();
		}
		#endregion
		
		/// <summary>
		/// Initializes the timer for next life.
		/// </summary>
		private void initTimer() {
			remainingSecondsWithInfiniteLives = calculateRemainingInfiniteLivesTime().TotalSeconds;
			if(!HasInfiniteLives) {
				secondsToNextLife = calculateLifeRecovery().TotalSeconds;
			}
			calculateSteps = true;
			notifyAll();
		}
		
		private bool validateUniqueInstance() {
			var livesManagers = FindObjectsOfType<LivesManager>();
			for(int i = 0; i < livesManagers.Length; i++) {
				if (livesManagers[i].AdvancedSettings.Id == AdvancedSettings.Id && livesManagers[i] != this)
					return false;
			}
			return true;
		}
		
		#region Data persistance
		/// <summary>
		/// Retrieves lives information from previous sessions.
		/// </summary>
		private void retrievePlayerPrefs() {
			remainingSecondsWithInfiniteLives = 0D;
			data = repository.Retrieve(AdvancedSettings.Id);
			if (data.MaxLives == null) data.MaxLives = BaseSettings.DefaultMaxLives;
			if (data.Lives == null) data.Lives = data.MaxLives;
			if(data.Lives > MaxLives) {
				FillLives();
			}
			notifyAll();
		}
		
		/// <summary>
		/// Saves the recovery start time to use it next time the Lives Manager is available 
		/// (on application restart, for example).
		/// </summary>
		private void savePlayerPrefs() {
			repository.Save(AdvancedSettings.Id, data);
		}
		
		/// <summary>
		/// Resets all the preferences of the LivesManager. Use with care.
		/// </summary>
		public void ResetPlayerPrefs() {
			repository.Reset(AdvancedSettings.Id);
			
			// When fired from the inspector, ommit this part.
			if (Application.isPlaying) {
				notificationScheduler.ClearNotification();
				retrievePlayerPrefs();
			}
		}
		#endregion
		
		#region TimeToNextLife control
		/// <summary>
		/// Calculates the time remaining for the next life, and recovers all possible lives.
		/// </summary>
		/// <returns>Time remaining for the next life.</returns>
		private TimeSpan calculateLifeRecovery() {
			DateTime now = DateTime.Now;
			TimeSpan elapsed = now - data.RecoveryStartTime;
			double minutesElapsed = elapsed.TotalMinutes;

			if (AdvancedSettings.AllOrNothing && (minutesElapsed >= BaseSettings.MinutesToRecover)) {
				FillLives();
			}
			else {
				while ((!HasMaxLives) && (minutesElapsed >= BaseSettings.MinutesToRecover)) {
					data.Lives++;
					data.RecoveryStartTime = DateTime.Now;
					minutesElapsed -= BaseSettings.MinutesToRecover;
				}
			}
			
			savePlayerPrefs();
			
			if(HasMaxLives) {
				return TimeSpan.Zero;
			} else {
				return TimeSpan.FromMinutes(BaseSettings.MinutesToRecover - minutesElapsed);
			}
		}
		
		/// <summary>
		/// Calculates the time remaining with infinite lives.
		/// </summary>
		/// <returns>The remaining infinite lives time.</returns>
		private TimeSpan calculateRemainingInfiniteLivesTime() {
			DateTime now = DateTime.Now;
			TimeSpan elapsed = now - data.InfiniteLivesStartTime;
			double minutesElapsed = elapsed.TotalMinutes;
			
			if(minutesElapsed < (double)data.InfiniteLivesMinutes) {
				return TimeSpan.FromMinutes(data.InfiniteLivesMinutes - minutesElapsed);
			} else {
				return TimeSpan.Zero;
			}
		}
		
		/// <summary>
		/// Calculates one step in the timer for next life.
		/// </summary>
		private void stepRecoveryTime() {
			if(HasInfiniteLives) {
				remainingSecondsWithInfiniteLives -= Time.unscaledDeltaTime;
				if(remainingSecondsWithInfiniteLives < 0D) {
					remainingSecondsWithInfiniteLives = 0D;
					data.InfiniteLivesMinutes = 0;
					data.InfiniteLivesStartTime = new DateTime(0);
					notifyLivesChanged();
				}
				notifyRecoveryTimeChanged();
			}else if (AdvancedSettings.AllOrNothing) {
				if (data.Lives == 0) {
					if (secondsToNextLife > 0D) {
						secondsToNextLife -= Time.unscaledDeltaTime;
						notifyRecoveryTimeChanged();
					}
					else {
						FillLives();
						notifyLivesChanged();
						setSecondsToNextLifeToZero();
					}
				}
			}
			else if(!HasMaxLives) {
				if(secondsToNextLife > 0D) {
					secondsToNextLife -= Time.unscaledDeltaTime;
					notifyRecoveryTimeChanged();
				} else {
					GiveOneLife();
					notifyLivesChanged();
					if(HasMaxLives) { setSecondsToNextLifeToZero();
					} else { resetSecondsToNextLife(); }
				}
			}
		}
		
		/// <summary>
		/// Sets the seconds to next life to zero.
		/// </summary>
		private void setSecondsToNextLifeToZero() {
			secondsToNextLife = 0;
			notifyRecoveryTimeChanged();
		}
		
		/// <summary>
		/// Resets the seconds to next life.
		/// </summary>
		private void resetSecondsToNextLife() {
			secondsToNextLife = BaseSettings.MinutesToRecover * 60;
			notifyRecoveryTimeChanged();
		}
		#endregion
		
		#region Notifications for observers
		/// <summary>
		/// Notifies all changes (time and lives) to the observers.
		/// </summary>
		private void notifyAll() {
			notifyRecoveryTimeChanged();
			notifyLivesChanged();
		}
		
		/// <summary>
		/// Notifies obvservers on recovery time changed.
		/// </summary>
		private void notifyRecoveryTimeChanged() { OnRecoveryTimeChanged.Invoke(RemainingTimeString); }
		
		/// <summary>
		/// Notifies observers on lives changed.
		/// </summary>
		private void notifyLivesChanged() { OnLivesChanged.Invoke(getCurrentLivesStatus()); }

		/// <summary>
		/// Creates a new instance of <see cref="LivesStatus"/> to report change.
		/// </summary>
		/// <returns>Current lives status.</returns>
		private LivesStatus getCurrentLivesStatus() { return new LivesStatus(data.Lives.Value, HasInfiniteLives, LivesText); }
		#endregion
	}
}