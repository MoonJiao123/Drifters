using UnityEngine;
using Unsorted;

namespace Walking {

	public class WalkController : MonoBehaviour {
		public HighwayBasis laneModule;
		public Transform target;

		public int Lane {
			get => lane;
			set => lane = Mathf.Clamp(value, -1, 1);
		}

		private int lane;

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			if (target != null) {
				Transform point = laneModule.Get(Lane);

				target.SetPositionAndRotation(point.position, point.rotation);
			}
		}
		#endregion MONOBEHAVIOUR
	}
}
