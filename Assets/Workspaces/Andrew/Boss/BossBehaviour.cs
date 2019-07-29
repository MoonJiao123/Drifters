using System;
using UnityEngine;

namespace Unsorted {

	public class BossBehaviour : MonoBehaviour {
		public float initialHealth;
		public GameObject endPortal;
		public GameObject boss;

		public string powerupTitle = "POWER UP!";
		public string powerupDescription = "You got a powerup!";
		public int powerupIndex = 0;

		void Start() {
			Boss.Health = initialHealth;
			Boss.MaxHealth = initialHealth;
		}

		void Awake() {
			Boss.Died += HandleDead;
		}

		void OnDestroy() {
			Boss.Died -= HandleDead;
		}

		void HandleDead(object sender, EventArgs e) {
			Scrim.Title = powerupTitle;
			Scrim.Description = powerupDescription;
			Scrim.Powerup = powerupIndex;
			Scrim.Show();

			switch (powerupIndex) {
				case 0:
					GameState.HasBrain = true;
					break;
				case 1:
					GameState.HasHeart = true;
					break;
				case 2:
					GameState.HasCourage = true;
					break;
			}
			Powerupper.Refresh();

			boss.SetActive(false);
			endPortal.SetActive(true);
		}
	}
}
