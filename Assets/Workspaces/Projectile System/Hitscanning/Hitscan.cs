using Andtech;
using System;
using UnityEngine;

namespace ProjectileSystem {

	public class Hitscan : SingletonBehaviour<Hitscan> {
		[SerializeField]
		private HitscanManager manager = default;

		public static bool Raycast(Vector3 position, Vector3 direction, out HitscanInfo scanInfo, float maxDistance) {
			return Current?.manager.Raycast(position, direction, out scanInfo, maxDistance);
		}

		public static bool Raycast(Vector3 position, Vector3 direction, out HitscanInfo scanInfo, float maxDistance, Vector3 muzzle) {
			return Current?.manager.Raycast(position, direction, out scanInfo, maxDistance, muzzle);
		}

		#region EVENT
		public static event EventHandler Launched {
			add => Current.manager.Launched += value;
			remove => Current.manager.Launched -= value;
		}
		public static event EventHandler Impacted {
			add => Current.manager.Impacted += value;
			remove => Current.manager.Impacted -= value;
		}
		#endregion EVENT
	}
}
