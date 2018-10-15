using ExaGames.Common.TimeBasedLifeSystem;
using UnityEngine;

public class DemoScript : MonoBehaviour {
	/// <summary>
	/// Reference to the LivesManager.
	/// </summary>
	public LivesManager LivesManager;
	/// <summary>
	/// Image display for the result of consuming a life.
	/// </summary>
	/// <remarks>
	/// This should be, for example, a reference to your game controller.
	/// </remarks>
	public DemoResultDisplayController ResultDisplay;

	private void Update() {
		#if UNITY_EDITOR
		/* When testing in the editor, you can use the keyboard to control the lives manager:
		 * C - Consume life
		 * G - Give one
		 * F - Fill lives
		 * A - Add one slot (increase max)
		 * Z - Add one slot and fill
		 * I - Give infinite lives
		 */ 

		if(Input.GetKeyUp(KeyCode.C)) { OnButtonConsumePressed(); }
		if(Input.GetKeyUp(KeyCode.G)) { OnButtonGiveOnePressed(); }
		if(Input.GetKeyUp(KeyCode.F)) { OnButtonFillPressed(); }
		if(Input.GetKeyUp(KeyCode.A)) { OnButtonIncreaseMaxPressed(); }
		if(Input.GetKeyUp(KeyCode.Z)) { LivesManager.AddLifeSlots(1, true); }
		if(Input.GetKeyUp(KeyCode.I)) { OnButtonInfinitePressed(); }
		#endif
	}

	#region Button Event Handlers
	/// <summary>
	/// Play (consume life) button event handler.
	/// </summary>
	public void OnButtonConsumePressed() {
		if(LivesManager.ConsumeLife()) {
			// Go to your game!
			Debug.Log("A life was consumed and the player can continue!");
			ResultDisplay.Show(true);
		} else {
			// Tell player to buy lives, then:
			// LivesManager.GiveOneLife();
			// or
			// LivesManager.FillLives();
			Debug.Log("Not enough lives to play!");
			ResultDisplay.Show(false);
		}
	}

	public void OnButtonGiveOnePressed() { LivesManager.GiveOneLife(); }

	public void OnButtonFillPressed() { LivesManager.FillLives(); }

	public void OnButtonInfinitePressed() { LivesManager.GiveInifinite(1); }

	public void OnButtonIncreaseMaxPressed() { LivesManager.AddLifeSlots(1); }

	public void OnButtonResetPressed() { LivesManager.ResetPlayerPrefs(); }
	#endregion
}