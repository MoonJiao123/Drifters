using UnityEngine;

namespace Unsorted {

	public class StepCounter : MonoBehaviour {
		public Transform target;

		public float Distance;

		private Vector3 lastPosition;

		void Update() {
			Vector3 delta = target.position - lastPosition;

			Distance += delta.magnitude;

			lastPosition = target.position;
		}

		void OnEnable() {
			lastPosition = target.position;
		}
	}
}
