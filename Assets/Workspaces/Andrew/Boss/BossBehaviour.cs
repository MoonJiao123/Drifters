using UnityEngine;

namespace Unsorted {

	public class BossBehaviour : MonoBehaviour {
		public float initialHealth;

		void Awake() {
			Boss.Health = initialHealth;
			Boss.MaxHealth = initialHealth;
		}
	}
}
