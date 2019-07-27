using UnityEngine;

namespace Unsorted {

	public class HighwayBasis : MonoBehaviour {
		[SerializeField]
		private Transform[] points;

		public Transform[] Points => points;

		public Transform Get(int lane) {
			switch (lane) {
				case -1:
					return Points[0];
				case 0:
					return Points[1];
				case 1:
					return Points[2];
			}

			return default;
		}

		public void GetPositionAndRotation(int lane, out Vector3 position, out Quaternion rotation) {
			Transform transform = Get(lane);

			position = transform.position;
			rotation = transform.rotation;
		}
	}
}
