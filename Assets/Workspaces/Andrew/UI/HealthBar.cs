using Andtech;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unsorted {

	public class HealthBar : MonoBehaviour {
		public Graphic hurt;
		public Image healthBar;
		public TextMeshProUGUI textHealth;
		public TextMeshProUGUI textHealthLabel;

		public Color colorHurt;

		void Awake() {
			Player.TookDamage += HandleDamage;
			Player.TookDamage += HandleDamage;
			Player.AddedHealth += HandleHealth;
		}

		void OnDestroy() {
			Player.TookDamage -= HandleDamage;
			Player.TookDamage -= HandleDamage;
			Player.AddedHealth -= HandleHealth;
		}

		void Start() {
			UpdateCounters();
		}

		void DisplayDamage() {
			StartCoroutine(Hurting(0.25F));
		}

		void UpdateCounters( ) {
			healthBar.fillAmount = Player.HealthAsPercentage;
			textHealth.text = string.Format("{0}%", Mathf.Round(100.0F * Player.HealthAsPercentage));
		}

		IEnumerator Hurting(float duration) {
			foreach (float alpha in AlphaCurve.Power(duration, 3.0F)) {
				hurt.color = Color.Lerp(colorHurt, Color.clear, alpha);

				yield return null;
			}
		}

		#region CALLBACK
		void HandleDamage(object sender, EventArgs e) {
			UpdateCounters();
			DisplayDamage();
		}

		void HandleHealth(object sender, EventArgs e) {
			UpdateCounters();
		}
		#endregion CALLBACK
	}
}
