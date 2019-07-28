using Andtech;
using Andtech.Pooling;
using ProjectileSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Effects {

	public class RicochetCreator : MonoBehaviour {
		[SerializeField]
		private Transform folder = default;
		[SerializeField]
		private Emitter prefab = default;
		private Pool<Emitter> pool;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			pool = PoolExtensions.Factory(prefab, folder);
			pool.Fill(10);
		}

		protected virtual void Start() {
			Hitscan.Launched += (object sender, EventArgs e) => {
				if (e is HitscanEventArgs args) {
					Emitter emitter = pool.Poll();

					emitter.transform.position = args.ScanInfo.hitInfo.point;
					emitter.transform.rotation = Quaternion.LookRotation(args.ScanInfo.hitInfo.normal);
				}			
			};
		}
		#endregion MONOBEHAVIOUR
	}
}
