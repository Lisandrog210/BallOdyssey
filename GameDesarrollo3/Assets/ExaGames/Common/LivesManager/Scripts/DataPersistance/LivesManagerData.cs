using System;

namespace ExaGames.Common.TimeBasedLifeSystem.DataPersistance {
	/// <summary>
	/// Data transfer object to carry the state of a <see cref="LivesManager"/> instance.
	/// </summary>
	public struct LivesManagerData {
		/// <summary>
		/// Maximum number of lives for the player.
		/// </summary>
		public int? MaxLives;
		/// <summary>
		/// Current number of available lives.
		/// </summary>
		public int? Lives;
		/// <summary>
		/// Timestamp from the last life recovery.
		/// </summary>
		public DateTime RecoveryStartTime;
		/// <summary>
		/// Timestamp when infinite lives started.
		/// </summary>
		public DateTime InfiniteLivesStartTime;
		/// <summary>
		/// Total minutes of infinite lives given to the player.
		/// </summary>
		public int InfiniteLivesMinutes;
	}
}