using Andtech;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Unsorted {

	public class VideoScene : MonoBehaviour {
		public int buildIndexNext;
		public float minWaitTime;
		public float maxWaitTime;

		public Graphic video;
		public Graphic graphic;

		#region MONOBEHAVIOUR
		IEnumerator Start() {
			video.color = Color.white;

			for (float t = 0.0F; t < minWaitTime; t += Time.deltaTime) {
				if (Input.GetKeyDown(KeyCode.Escape))
					goto Done;

				yield return null;
			}

			StartCoroutine(ShowMessage(3.0F));

			float wait = maxWaitTime - minWaitTime;
			for (float t = 0.0F; t < wait; t += Time.deltaTime) {
				if (Input.GetKeyDown(KeyCode.Space))
					goto Done;

				if (Input.GetKeyDown(KeyCode.Escape))
					goto Done;

				yield return null;
			}

			Done:
			SceneManager.LoadScene(buildIndexNext);
		}
		#endregion MONOBEHAVIOUR

		IEnumerator ShowMessage(float duration) {
			foreach (float alpha in AlphaCurve.PowerInverse(duration, 3.0F)) {
				graphic.color = new Color(1.0F, 1.0F, 1.0F, alpha);

				yield return null;
			}
		}

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
