using UnityEngine;

namespace Unsorted {

	public class LinearHighwayMotor : MonoBehaviour {
		public float speed;
		public HighwayBasis target;

		#region MONOBEHAVIOUR
		void Update() {
			Vector3 position = target.Position;
			Vector3 velocity = target.Tangent * speed;

			target.Position += velocity * Time.deltaTime;
		}
        #endregion MONOBEHAVIOUR
	}
}
