using UnityEngine;

namespace Unsorted {

	public class OnlyAppear : MonoBehaviour {

		#region MONOBEHAVIOUR
		void Awake() {
			if (GameState.HasBrain && GameState.HasCourage && GameState.HasHeart) { }
			else
				Destroy(gameObject);
		}
        #endregion MONOBEHAVIOUR

        #region OVERRIDE
        #endregion OVERRIDE

        #region VIRTUAL
        #endregion VIRTUAL

        #region ABSTRACT
        #endregion ABSTRACT

        #region INTERFACE
        #endregion INTERFACE

        #region COROUTINE
        #endregion COROUTINE

        #region CALLBACK
        #endregion CALLBACK

        #region EVENT
        #endregion EVENT

        #region PIPELINE
        #endregion PIPELINE
	}
}
