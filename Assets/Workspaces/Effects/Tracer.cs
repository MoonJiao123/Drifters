using Andtech.Pooling;
using System;
using UnityEngine;

namespace Effects {

	public class Tracer : MonoBehaviour, IPoolable {
		[SerializeField]
		private Transform transformFill = default;

		public void SetPoints(Vector3 tip, Vector3 tail) {
			// You can optimize this!
			Vector3 delta = tip - tail;
			Quaternion rotation = delta.sqrMagnitude == 0.0F ? Quaternion.identity : Quaternion.LookRotation(-delta);
			float distance = delta.magnitude;

			transform.position = tip;
			transformFill.rotation = rotation;
			transformFill.localScale = new Vector3(distance, distance, distance);
		}

		#region INTERFACE
		void IPoolable.RequestReclaim() {
			OnRequestReclaim(EventArgs.Empty);
		}

		void IPoolable.OnDispatch() {
			gameObject.SetActive(true);
		}

		void IPoolable.OnReclaim() {
			gameObject.SetActive(false);
		}

		event EventHandler IPoolable.RequestedReclaim {
			add {
				requestedReclaim += value;
			}
			remove {
				requestedReclaim -= value;
			}
		}
		#endregion INTERFACE

		#region EVENT
		private event EventHandler requestedReclaim;

		protected virtual void OnRequestReclaim(EventArgs e) => requestedReclaim?.Invoke(this, e);
		#endregion EVENT
	}
}
