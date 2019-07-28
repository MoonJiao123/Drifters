using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unsorted {

	public class AutoRestarter : MonoBehaviour {

		void Awake() {
			if (!GameState.HasBooted) {
				Debug.LogWarning("Auto-booting...");
				SceneManager.LoadScene(0);
			}
		}

        #region MONOBEHAVIOUR
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
