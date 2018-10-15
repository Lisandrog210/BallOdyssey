using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSceneButtonController : MonoBehaviour {
	public string GotoSceneName;
	public void OnButtonPressed() {
#if UNITY_5_2
		Application.LoadLevel(GotoSceneName);	
#else
		SceneManager.LoadScene(GotoSceneName);
#endif
	}
}
