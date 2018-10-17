using UnityEngine;
using UnityEngine.UI;

namespace ExaGames.Common.TimeBasedLifeSystem.Display {
	/// <summary>
	/// Controls text display of the number of lives.
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class LivesNumberTextDisplay : MonoBehaviour {
		private Text _textComponent;

		private Text textComponent {
			get {
				if (_textComponent == null) _textComponent = GetComponent<Text>();
				return _textComponent;
			}
		}

		/// <summary>
		/// Lives changed event handler, changes the label value.
		/// </summary>
		/// <param name="livesStatus">Current lives status reported by the <see cref="LivesManager"/>.</param>
		public void OnLivesChanged(LivesStatus livesStatus) {
           
			textComponent.text = livesStatus.LivesText;
		}
	}
}