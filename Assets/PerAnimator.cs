using UnityEngine;

namespace Unsorted {

	public class PerAnimator : MonoBehaviour {
		public Animator animator;

		public Transform target;
		public float maxSpeed;

		private Vector3 lastPosition;

		#region MONOBEHAVIOUR
		void OnEnable() {
			lastPosition = target.position;
		}

		void Update() {
			Vector3 position = target.position;
			Vector3 delta = position - lastPosition;
			float distance = delta.magnitude;
			float speed = distance / Time.deltaTime;
			float alpha = Mathf.Clamp01(speed / maxSpeed);

			animator.SetFloat("MoveSpeed", alpha);

			lastPosition = position;
		}
        #endregion MONOBEHAVIOUR
	}
}
