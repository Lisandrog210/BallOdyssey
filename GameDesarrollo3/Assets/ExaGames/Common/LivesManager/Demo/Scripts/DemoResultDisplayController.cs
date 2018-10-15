using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DemoResultDisplayController : MonoBehaviour {

	public Sprite SuccessSprite;
	public Sprite FailSprite;
	public float FadeOutSpeed;

	private Image img;
	
	private void Start() {
		img = GetComponent<Image>();
		img.color = new Color(1f, 1f, 1f, 0f);
	}

	public void Show(bool result) {
		img.sprite = result ? SuccessSprite : FailSprite;
		StartCoroutine(fadeOut());
	}

	private IEnumerator fadeOut() {
		var alpha = 1f;
		while(alpha>0) {
			img.color = new Color(1f, 1f, 1f, alpha);
			alpha -= FadeOutSpeed * Time.deltaTime;
			yield return null;
		}
		img.color = new Color(1f, 1f, 1f, 0f);
	}
}