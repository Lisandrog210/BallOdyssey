using UnityEditor;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem {
	/// <summary>
	/// Custom editor for <see cref="LivesManager"/> game objects.
	/// </summary>
	[CustomEditor(typeof(LivesManager))]
	public class LivesManagerEditor : Editor {
		public override void OnInspectorGUI() {
			var livesManager = (LivesManager)target;

			if (GUILayout.Button(new GUIContent("Reset PlayerPrefs now", "Resets the all the preferences of the LivesManager. Use with care."))) {
				livesManager.ResetPlayerPrefs();
				Debug.Log("LivesManager values at PlayerPrefs have been reseted.");
			}

			if (Application.isPlaying && livesManager.AdvancedSettings.DebugOptions.InspectorDebugging) {
				if (livesManager.HasInfiniteLives) {
					EditorGUILayout.LabelField("Current Lives: Infinite");
				}
				else {
					EditorGUILayout.LabelField(string.Format("Current Lives: {0}", livesManager.Lives));
				}
				EditorGUILayout.LabelField(string.Format("Remaining Time: {0}", livesManager.RemainingTimeSpan.ToString()));
				EditorGUILayout.Space();
				EditorGUILayout.LabelField(string.Format("Max Lives: {0}", livesManager.MaxLives));
				EditorGUILayout.LabelField(string.Format("Minutes To Recover: {0}", livesManager.BaseSettings.MinutesToRecover));
				EditorGUILayout.Space();
				if (livesManager.AdvancedSettings.AllOrNothing) {
					EditorGUILayout.LabelField("Timer will start when all lives are consumed.");
					EditorGUILayout.LabelField("Lives will be filled when timer reaches 0.");
				}
				if (livesManager.LocalNotificationSettings.AllowLocalNotifications) {
					EditorGUILayout.LabelField("Local notifications are enabled.");
				}
				EditorUtility.SetDirty(target);
			}
			else {
				DrawDefaultInspector();
			}
		}

		private void OnSceneGUI() {
			
		}
	}
}