using UnityEngine;

namespace ProjectileSystem {

	public struct HitscanInfo {
		public Vector3 origin;
		public Vector3 muzzle;
		public Vector3 direction;
		public RaycastHit hitInfo;
		public float maxDistance;
		public bool success;
	}
}
