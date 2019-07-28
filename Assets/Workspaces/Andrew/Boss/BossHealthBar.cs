using Andtech;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Unsorted {

	public class BossHealthBar : MonoBehaviour {
		public Image healthBar;
		public TextMeshProUGUI textHealth;
		public TextMeshProUGUI textHealthLabel;

		void Awake() {
			Boss.TookDamage += HandleDamage;
		}

		void OnDestroy() {
			Boss.TookDamage -= HandleDamage;
		}

		void Start() {
			UpdateCounters();
		}

		void UpdateCounters() {
			healthBar.fillAmount = Boss.HealthAsPercentage;
			textHealth.text = string.Format("{0} HP", Boss.Health);
		}

		#region CALLBACK
		void HandleDamage(object sender, EventArgs e) {
			UpdateCounters();
		}
		#endregion CALLBACK
	}
}
