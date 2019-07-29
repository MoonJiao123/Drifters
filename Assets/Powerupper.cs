using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Unsorted {

	public class Powerupper : MonoBehaviour {
		public FirstPersonController foo;

		[Space]
		public float regenerateRate;
		public float regenerateAmount;

		[Space]
		public float fastWalkSpeed;
		public float fastRunSpeed;

		[Space]
		public float armourMultiplier;

		public static void Refresh() {
			foreach (Powerupper powerupper in FindObjectsOfType<Powerupper>()) {
				powerupper.Try();
			}
		}

		void Start() {
			Try();
		}

		void Regen() {
			Player.AddHealth(regenerateAmount);
		}

		void Try() {

			if (GameState.HasBrain) {
				foo.m_WalkSpeed = fastWalkSpeed;
				foo.m_RunSpeed = fastRunSpeed;
			}
			if (GameState.HasCourage) {
				Player.ArmorMultiplier = armourMultiplier;
			}
			if (GameState.HasHeart) {
				InvokeRepeating("Regen", regenerateRate, regenerateRate);
			}
		}
	}
}
