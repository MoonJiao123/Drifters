using System;
using UnityEngine;

namespace ProjectileSystem {

	public class HitscanManager : MonoBehaviour {
		public LayerMask layerMask;

		public bool Raycast(Vector3 position, Vector3 direction, out HitscanInfo scanInfo, float maxDistance) {
			return Raycast(position, direction, out scanInfo, maxDistance, position);
		}

		public bool Raycast(Vector3 position, Vector3 direction, out HitscanInfo scanInfo, float maxDistance, Vector3 muzzle) {
			scanInfo = default;
			scanInfo.origin = position;
			scanInfo.direction = direction;
			scanInfo.maxDistance = maxDistance;
			scanInfo.muzzle = muzzle;

			bool success = Physics.Raycast(position, direction, out scanInfo.hitInfo, maxDistance, layerMask);
			scanInfo.success = success;

			// Events processing
			HitscanEventArgs args = new HitscanEventArgs(scanInfo);
			Launched?.Invoke(this, args);
			if (success)
				Impacted?.Invoke(this, args);

			return success;
		}

		#region EVENT
		public event EventHandler Launched;
		public event EventHandler Impacted;
		#endregion EVENT
	}
}
