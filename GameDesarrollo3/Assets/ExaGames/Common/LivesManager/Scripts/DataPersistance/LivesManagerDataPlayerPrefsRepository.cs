using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.DataPersistance {
	/// <summary>
	/// Implements <see cref="ILivesManagerDataRepository"/> to use PlayerPrefs as backend.
	/// </summary>
	public class LivesManagerDataPlayerPrefsRepository : ILivesManagerDataRepository {
		#region Constants
		/// <summary>
		/// Key to save the maximum number of lives for the player.
		/// </summary>
		private const string MAX_LIVES_SAVEKEY = "ExaGames.Common.MaxLives";
		/// <summary>
		/// Key to save the number of currently available lives in the player preferences file.
		/// </summary>
		private const string LIVES_SAVEKEY = "ExaGames.Common.Lives";
		/// <summary>
		/// Key to save the recovery start time in the player preferences file.
		/// </summary>
		private const string RECOVERY_TIME_SAVEKEY = "ExaGames.Common.LivesRecoveryTime";
		/// <summary>
		/// Key to save the starting time of infinite lives.
		/// </summary>
		private const string INFINITE_LIVES_TIME_SAVEKEY = "ExaGames.Common.InfiniteLivesStartTime";
		/// <summary>
		/// Key to save the total minutes of infinite lives given to the player.
		/// </summary>
		private const string INFINITE_LIVES_MINUTES_SAVEKEY = "ExaGames.Common.InfiniteLivesMinutes";
		#endregion

		/// <summary>
		/// Deletes the PlayerPrefs keys corresponding to the <see cref="LivesManager"/> instance identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Id of the <see cref="LivesManager"/> to reset.</param>
		public void Reset(string id) {
			PlayerPrefs.DeleteKey(getSaveKey(MAX_LIVES_SAVEKEY, id));
			PlayerPrefs.DeleteKey(getSaveKey(RECOVERY_TIME_SAVEKEY, id));
			PlayerPrefs.DeleteKey(getSaveKey(LIVES_SAVEKEY, id));
			PlayerPrefs.DeleteKey(getSaveKey(INFINITE_LIVES_TIME_SAVEKEY, id));
			PlayerPrefs.DeleteKey(getSaveKey(INFINITE_LIVES_MINUTES_SAVEKEY, id));
		}

		/// <summary>
		/// Retrieves the <see cref="LivesManagerData"/> for the <see cref="LivesManager"/> instance identified by <paramref name="id"/> from <see cref="PlayerPrefs"/>.
		/// </summary>
		/// <param name="id">Id of the <see cref="LivesManager"/> to retrieve its data.</param>
		/// <returns>Persisted data of the <see cref="LivesManager"/> identified by <paramref name="id"/>.</returns>
		public LivesManagerData Retrieve(string id) {
			LivesManagerData result = new LivesManagerData();
			var maxLivesSaveKey = getSaveKey(MAX_LIVES_SAVEKEY, id);
			var infiniteLivesTimeSaveKey = getSaveKey(INFINITE_LIVES_TIME_SAVEKEY, id);
			var infiniteLivesMinutesSaveKey = getSaveKey(INFINITE_LIVES_MINUTES_SAVEKEY, id);
			var livesSaveKey = getSaveKey(LIVES_SAVEKEY, id);
			var recoveryTimeSaveKey = getSaveKey(RECOVERY_TIME_SAVEKEY, id);

			result.MaxLives = PlayerPrefs.HasKey(maxLivesSaveKey) ? PlayerPrefs.GetInt(maxLivesSaveKey) : (int?)null;
			if (PlayerPrefs.HasKey(infiniteLivesTimeSaveKey) && PlayerPrefs.HasKey(infiniteLivesMinutesSaveKey)) {
				result.InfiniteLivesStartTime = new DateTime(long.Parse(PlayerPrefs.GetString(infiniteLivesTimeSaveKey)));
				result.InfiniteLivesMinutes = PlayerPrefs.GetInt(infiniteLivesMinutesSaveKey);
			}
			else {
				result.InfiniteLivesStartTime = DateTime.MinValue;
				result.InfiniteLivesMinutes = 0;
			}
			if (PlayerPrefs.HasKey(livesSaveKey) && PlayerPrefs.HasKey(recoveryTimeSaveKey)) {
				result.Lives = PlayerPrefs.GetInt(livesSaveKey);
				result.RecoveryStartTime = new DateTime(long.Parse(PlayerPrefs.GetString(recoveryTimeSaveKey)));
			}
			else {
				result.RecoveryStartTime = DateTime.Now;
			}
			return result;
		}

		/// <summary>
		/// Saves the state of the <see cref="LivesManager"/> instance identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Id of the <see cref="LivesManager"/> to persist.</param>
		/// <param name="data">Data to persist.</param>
		public void Save(string id, LivesManagerData data) {
			#region Data validation
			var validationError = validateSaveData(data);
			if (!string.IsNullOrEmpty(validationError)) {
				Debug.LogError(validationError);
				return;
			}
			#endregion

			PlayerPrefs.SetInt(getSaveKey(MAX_LIVES_SAVEKEY, id), data.MaxLives.Value);
			PlayerPrefs.SetInt(getSaveKey(LIVES_SAVEKEY, id), data.Lives.Value);
			PlayerPrefs.SetString(getSaveKey(RECOVERY_TIME_SAVEKEY, id), data.RecoveryStartTime.Ticks.ToString());
			PlayerPrefs.SetString(getSaveKey(INFINITE_LIVES_TIME_SAVEKEY, id), data.InfiniteLivesStartTime.Ticks.ToString());
			PlayerPrefs.SetInt(getSaveKey(INFINITE_LIVES_MINUTES_SAVEKEY, id), data.InfiniteLivesMinutes);
			try {
				PlayerPrefs.Save();
			}
			catch (Exception e) {
				Debug.LogErrorFormat("Could not save LivesManager {0} preferences: {1}", id, e.Message);
			}
		}

		private string validateSaveData(LivesManagerData data) {
			var errors = new List<string>();

			if (data.MaxLives == null) errors.Add("MaxLives can't be null");
			if (data.Lives == null) errors.Add("Lives can't be null");

			if (errors.Count > 0) {
				return string.Format("Can't save LivesManagerData, please fix the following errors: {0}", string.Join("; ", errors.ToArray()));
			}
			return null;
		}

		private string getSaveKey(string prefix, string livesManagerId) {
			if (string.IsNullOrEmpty(livesManagerId)) return prefix;
			return string.Format("{0}.{1}", prefix, livesManagerId);
		}
	}
}