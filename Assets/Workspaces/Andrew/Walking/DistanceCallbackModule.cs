using UnityEngine;

namespace Unsorted {

	public class DistanceCallbackModule : MonoBehaviour {
		public float limit;
		public StepCounter counter;

		#region MONOBEHAVIOUR
		void LateUpdate() {
			if (counter.Distance > limit) {
				Debug.Log("DONE WALKING SOON");
				GameState.NextLevel();
			}
		}
        #endregion MONOBEHAVIOUR
	}
}
