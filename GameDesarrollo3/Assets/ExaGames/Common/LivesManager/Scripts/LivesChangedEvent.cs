using System;
using UnityEngine.Events;

namespace ExaGames.Common.TimeBasedLifeSystem {
	/// <summary>
	/// Callback receiver for lives changed events.
	/// </summary>
	[Serializable]
	public class LivesChangedEvent : UnityEvent<LivesStatus> { }

	/// <summary>
	/// Contains data about the current status of lives.
	/// </summary>
	public class LivesStatus {
		/// <summary>
		/// Gets the current number of lives.
		/// </summary>
		public int CurrentLives { get; private set; }
		/// <summary>
		/// Indicates whether infinite lives mode is active.
		/// </summary>
		public bool HasInfiniteLives { get; private set; }
		/// <summary>
		/// Gets the appropriate text to be shown in a "Lives" label.
		/// </summary>
		public string LivesText { get; private set; }

		/// <summary>
		/// Creates an instance of <see cref="LivesStatus"/>.
		/// </summary>
		/// <param name="currentLives">Number of lives.</param>
		/// <param name="hasInfiniteLives">Indicates whether infinite lives mode is active.</param>
		/// <param name="livesText">Text to be shown in a "Lives" label.</param>
		public LivesStatus(int currentLives, bool hasInfiniteLives, string livesText) {
			CurrentLives = currentLives;
			HasInfiniteLives = hasInfiniteLives;
			LivesText = livesText;
		}
	}
}