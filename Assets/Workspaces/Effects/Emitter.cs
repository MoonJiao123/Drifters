using Andtech.Pooling;
using System;
using System.Collections;
using UnityEngine;

public class Emitter : MonoBehaviour, IPoolable {
	[SerializeField]
	private new ParticleSystem particleSystem = default;

	#region INTERFACE
	void IPoolable.RequestReclaim() {
		OnRequestReclaim(EventArgs.Empty);
	}

	void IPoolable.OnDispatch() {
		particleSystem.Clear();
		particleSystem.Play();
		gameObject.SetActive(true);

		StartCoroutine(Waiting());
	}

	void IPoolable.OnReclaim() {
		gameObject.SetActive(false);
	}

	event EventHandler IPoolable.RequestedReclaim {
		add {
			requestReclaim += value;
		}
		remove {
			requestReclaim -= value;
		}
	}
	#endregion INTERFACE

	#region COROUTINE
	private IEnumerator Waiting() {
		yield return new WaitForSeconds(particleSystem.main.duration);

		(this as IPoolable).RequestReclaim();
	}
	#endregion COROUTINE

	#region EVENT
	private event EventHandler requestReclaim;

	protected virtual void OnRequestReclaim(EventArgs e) => requestReclaim?.Invoke(this, e);
	#endregion EVENT
}
