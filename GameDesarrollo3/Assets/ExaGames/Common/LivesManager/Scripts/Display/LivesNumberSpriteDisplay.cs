using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.Display {
	[RequireComponent(typeof(RectTransform))]
	public class LivesNumberSpriteDisplay : MonoBehaviour {
		/// <summary>
		/// Prefab of the normal life
		/// </summary>
		public GameObject LifeSpritePrefab;
		/// <summary>
		/// Prefab of the infinite lives
		/// </summary>
		public GameObject InfiniteLivesSpritePrefab;

		private RectTransform _container;
		private RectTransform container {
			get {
				if (_container == null) _container = GetComponent<RectTransform>();
				return _container;
			}
		}

		private GameObject _infiniteLifeSprite;
		private GameObject infiniteLifeSprite {
			get {
				if (_infiniteLifeSprite == null) _infiniteLifeSprite = createChild(InfiniteLivesSpritePrefab, "InfiniteLives");
				return _infiniteLifeSprite;
			}
		}
		private List<GameObject> lifeSprites = new List<GameObject>();

		/// <summary>
		/// Lives changed event handler, changes the sprites.
		/// </summary>
		/// <param name="livesStatus">Current lives status reported by the <see cref="LivesManager"/>.</param>
		public void OnLivesChanged(LivesStatus livesStatus) {
			if (livesStatus.HasInfiniteLives) {
				var activeSprites = lifeSprites.Where(s => s.activeSelf);
				foreach (var sprite in activeSprites) {
					sprite.SetActive(false);
				}

				infiniteLifeSprite.SetActive(true);
			}
			else {
				infiniteLifeSprite.SetActive(false);

				// Create additional sprites if there's not enough of them to show the current lives.
				if (lifeSprites.Count() < livesStatus.CurrentLives) {
					OnMaxLivesChanged(livesStatus.CurrentLives);
				}

				while (lifeSprites.Where(s => s.activeSelf).Count() < livesStatus.CurrentLives) {
					lifeSprites.Where(s => !s.activeSelf).First().SetActive(true);
				}
				while (lifeSprites.Where(s => s.activeSelf).Count() > livesStatus.CurrentLives) {
					lifeSprites.Where(s => s.activeSelf).First().SetActive(false);
				}
			}
		}

		/// <summary>
		/// Max lives changed event handler, ensures we have enough sprites available to show all the lives.
		/// </summary>
		/// <param name="newMaxLives">New maximum number of lives the player can have.</param>
		public void OnMaxLivesChanged(int newMaxLives) {
			var currentLifeSprites = lifeSprites.Count;
			if (currentLifeSprites < newMaxLives) {
				for (int i = currentLifeSprites; i < newMaxLives; i++) {
					lifeSprites.Add(createChild(LifeSpritePrefab, "LifeSprite"));
				}
			}
			else if (currentLifeSprites > newMaxLives) {
				for (int i = currentLifeSprites; i > newMaxLives; i--) {
					destroyLifeSlot();
				}
			}
		}

		private GameObject createChild(GameObject prefab, string name) {
			var child = Instantiate(prefab);
			child.transform.SetParent(container);
			child.name = name;
			child.transform.localScale = Vector3.one;
			child.SetActive(false);
			return child;
		}

		private void destroyLifeSlot() {
			if (lifeSprites.Count == 0) {
				Debug.LogError("Lives display contains no life sprites.");
				return;
			}

			var destroyable = lifeSprites.Where(s => !s.activeSelf).FirstOrDefault(); // Prefer destroying inactive slots.
			if(destroyable==null) destroyable = lifeSprites[0];

			lifeSprites.Remove(destroyable);
			DestroyImmediate(destroyable);
		}
	}
}