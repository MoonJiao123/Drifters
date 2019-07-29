using Andtech;
using UnityEngine;

namespace Unsorted {

	public class Pet : MonoBehaviour {
		public Transform destination;
		public float smoothTimePosition;
		public float smoothTimeForward;

		private Vector3 velocityPosition;
		private Vector3 velocityForward;

		#region MONOBEHAVIOUR
		void LateUpdate() {
			Vector3 currentPosition = transform.position;
			Vector3 terminusPosition = destination.position;

			Vector3 position = new Vector3 {
				x = Mathf.SmoothDamp(currentPosition.x, terminusPosition.x, ref velocityPosition.x, smoothTimePosition),
				y = Mathf.SmoothDamp(currentPosition.y, terminusPosition.y, ref velocityPosition.y, smoothTimePosition),
				z = Mathf.SmoothDamp(currentPosition.z, terminusPosition.z, ref velocityPosition.z, smoothTimePosition),
			};
			transform.position = position;

			Vector3 currentForward = transform.forward;
			Vector3 terminusForward = VectorUtility.ProjectOnPlaneY(terminusPosition - currentPosition);
			Vector3 forward = new Vector3 {
				x = Mathf.SmoothDamp(currentForward.x, terminusForward.x, ref velocityForward.x, smoothTimeForward),
				y = Mathf.SmoothDamp(currentForward.y, terminusForward.y, ref velocityForward.y, smoothTimeForward),
				z = Mathf.SmoothDamp(currentForward.z, terminusForward.z, ref velocityForward.z, smoothTimeForward),
			};
			transform.rotation = Quaternion.LookRotation(forward);
		}
        #endregion MONOBEHAVIOUR
	}
}
