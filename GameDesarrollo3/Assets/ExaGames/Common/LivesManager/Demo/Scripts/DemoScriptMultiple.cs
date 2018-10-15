using ExaGames.Common.TimeBasedLifeSystem;
using UnityEngine;

public class DemoScriptMultiple : MonoBehaviour {
	public LivesManager LivesManager;
	public LivesManager EnergyManager;

	public void OnLivesManagerConsumeButtonPressed() {
		if (LivesManager.ConsumeLife()) {
			// Go to your game!
			Debug.Log("A life was consumed and the player can continue!");
		}
		else {
			// Tell player to buy lives, then:
			// LivesManager.GiveOneLife();
			// or
			// LivesManager.FillLives();
			Debug.Log("Not enough lives to play!");
		}
	}

	public void OnEnergyManagerConsumeButtonPressed() {
		if (EnergyManager.ConsumeLife()) {
			// Go to your game!
			Debug.Log("A life was consumed and the player can continue!");
		}
		else {
			// Tell player to buy lives, then:
			// LivesManager.GiveOneLife();
			// or
			// LivesManager.FillLives();
			Debug.Log("Not enough lives to play!");
		}
	}
}