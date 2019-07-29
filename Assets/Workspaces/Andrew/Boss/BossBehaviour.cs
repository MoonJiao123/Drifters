using System;
using UnityEngine;

namespace Unsorted {

	public class BossBehaviour : MonoBehaviour {
		public float initialHealth;
		public GameObject endPortal;
		public GameObject boss;

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
			Scrim.Title = "TITLE";
			Scrim.Description = "POWERUP?";
			Scrim.Show();

			boss.SetActive(false);
			endPortal.SetActive(true);
		}
	}
}
