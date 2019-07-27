﻿using System;
using UnityEngine;

namespace Andtech.Pooling {

	public class PoolModule : MonoBehaviour, IPoolable {

		#region VIRTUAL
		protected virtual void RequestReclaim() {
			OnRequestReclaim(EventArgs.Empty);
		}

		protected virtual void OnDispatch() {
			gameObject.SetActive(true);
		}

		protected virtual void OnReclaim() {
			gameObject.SetActive(false);
		}
		#endregion VIRTUAl

		#region INTERFACE
		void IPoolable.RequestReclaim() {
			RequestReclaim();
		}

		void IPoolable.OnDispatch() {
			OnDispatch();
		}

		void IPoolable.OnReclaim() {
			OnReclaim();
		}

		event EventHandler IPoolable.RequestedReclaim {
			add => requestedReclaim += value;

			remove => requestedReclaim -= value;
		}
		#endregion INTERFACE

		#region EVENT
		private event EventHandler requestedReclaim;

		protected virtual void OnRequestReclaim(EventArgs e) => requestedReclaim?.Invoke(this, e);
		#endregion EVENT
	}
}
