using UnityEngine;

namespace Unsorted {

	public class BossLogic : MonoBehaviour {
		public float refreshRate;

		public Transform enemy;
		public Transform player;
		public float range;

		[Header("Animation")]
		public Animator animator;
		public string parameterName;

		void Refresh() {
			Vector3 delta = player.position - enemy.position;
			float sqrDistance = delta.sqrMagnitude;

			bool inRange = sqrDistance < range * range;
			animator?.SetBool(parameterName, inRange);

			if (sqrDistance < range * range) {
				Debug.Log("ATTACK HIT");
				Debug.DrawLine(enemy.position, player.position, Color.red, refreshRate);
			}
			else 
				Debug.DrawRay(enemy.position, delta.normalized * range, Color.white, refreshRate);
		}

		#region MONOBEHAVIOUR
		void OnEnable() {
			InvokeRepeating("Refresh", 0.0F, refreshRate);
		}

		void OnDisable() {
			CancelInvoke();
		}
		#endregion MONOBEHAVIOUR
	}
}
