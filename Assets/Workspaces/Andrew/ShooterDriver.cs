using ProjectileSystem;
using UnityEngine;

namespace Unsorted {

	public class ShooterDriver : MonoBehaviour {
		public Transform actionPoint;
		public float maxDistance;

		public AudioSource audioSource;

		public float rateOfFire;

		void Update() {
			if (Input.GetKeyDown(KeyCode.Mouse0))
				StartFire();
			if (Input.GetKeyUp(KeyCode.Mouse0))
				StopFire();
		}

		void Fire() {
			bool success = Hitscan.Raycast(actionPoint.position, actionPoint.forward, out HitscanInfo scanInfo, maxDistance);
			audioSource?.Play();

			if (success) {
				Debug.DrawRay(actionPoint.position, scanInfo.hitInfo.point, Color.white, 0.1F);
			}
			else {
				Debug.DrawRay(actionPoint.position, actionPoint.forward * maxDistance, Color.red, 0.1F);
			}
		}

		void StartFire() {
			InvokeRepeating("Fire", 0.0F, rateOfFire);
		}

		void StopFire() {
			CancelInvoke();
		}

		void OnDrawGizmosSelected() {
			Gizmos.DrawRay(actionPoint.position, actionPoint.forward * maxDistance);
		}
	}
}
