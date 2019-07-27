using Andtech;
using Andtech.Pooling;
using ProjectileSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Effects {

	public class TracerCallbackModule : MonoBehaviour {
		public float speed;
		public float length;

		[SerializeField]
		private Transform folder = default;
		[SerializeField]
		private Tracer tracerPrefab = default;
		private Pool<Tracer> tracerPool;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			tracerPool = PoolExtensions.Factory(tracerPrefab, folder);
			tracerPool.Fill(10);
		}

		protected virtual void Start() {
			Hitscan.Launched += DrawTracer;
		}
		#endregion MONOBEHAVIOUR

		#region COROUTINE
		private IEnumerator Tracing(Vector3 from, Vector3 to, float speed, float length, Color color) {
			float distance = Vector3.Distance(from, to);
			float duration = distance / speed;

			Tracer tracer = tracerPool.Poll();
			foreach (float alpha in AlphaCurve.Linear(duration)) {
				Vector3 tip = Vector3.Lerp(from, to, alpha);
				Vector3 tail = Vector3.Lerp(from, to, alpha - length / distance);

				tracer.SetPoints(tip, tail);

				yield return null;
			}

			(tracer as IPoolable)?.RequestReclaim();
		}
		#endregion COROUTINE

		#region CALLBACK
		private void DrawTracer(object sender, EventArgs e) {
			if (e is HitscanEventArgs args) {
				Vector3 pointRaw;
				Vector3 muzzle = args.ScanInfo.muzzle;

				if (args.ScanInfo.success)
					pointRaw = args.ScanInfo.hitInfo.point;
				else
					pointRaw = args.ScanInfo.origin + args.ScanInfo.direction * args.ScanInfo.maxDistance;

				StartCoroutine(Tracing(muzzle, pointRaw, speed, length, Color.yellow));
			}
		}
		#endregion CALLBACK
	}
}
