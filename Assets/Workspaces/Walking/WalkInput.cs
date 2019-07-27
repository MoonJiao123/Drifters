using UnityEngine;

namespace Walking {

	public class WalkInput : MonoBehaviour {
		public WalkController controller;

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			int increment = 0;
			if (Input.GetKeyDown(KeyCode.LeftArrow))
				increment = -1;
			else if (Input.GetKeyDown(KeyCode.RightArrow))
				increment = 1;

			int nextLane = controller.Lane + increment;
			controller.Lane = nextLane;
		}
		#endregion MONOBEHAVIOUR
	}
}
