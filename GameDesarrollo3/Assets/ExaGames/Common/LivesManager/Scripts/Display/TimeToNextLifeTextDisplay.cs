using UnityEngine;
using UnityEngine.UI;

namespace ExaGames.Common.TimeBasedLifeSystem.Display {
	/// <summary>
	/// Controller for time-to-next-life text display.
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class TimeToNextLifeTextDisplay : MonoBehaviour {
		private Text _textComponent;
		private Text textComponent {
			get {
				if (_textComponent == null) _textComponent = GetComponent<Text>();
				return _textComponent;
			}
		}

		/// <summary>
		/// Time to next life changed event handler, changes the label value.
		/// </summary>
		/// <param name="remainingTimeString">String to replace the text in the label.</param>
		public void OnTimeToNextLifeChanged(string remainingTimeString) { textComponent.text = remainingTimeString; }
	}
}