namespace ExaGames.Common.TimeBasedLifeSystem.DataPersistance {
	/// <summary>
	/// Contains methods to save and retrieve <see cref="LivesManager"/>'s stats.
	/// </summary>
	public interface ILivesManagerDataRepository {
		/// <summary>
		/// Retrieves lives information from previous sessions of the <see cref="LivesManager"/> identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Id of the LivesManager to retrieve its data.</param>
		LivesManagerData Retrieve(string id);
		/// <summary>
		/// Saves the lives data for the <see cref="LivesManager"/> identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Id of the LivesManager to save its data.</param>
		/// <param name="data">Data to save.</param>
		void Save(string id, LivesManagerData data);
		/// <summary>
		/// Resets all the preferences of the <see cref="LivesManager"/> identified by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">Id of the LivesManager to reset.</param>
		void Reset(string id);
	}
}