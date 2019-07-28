using System.Collections.Generic;
using UnityEngine;

namespace Unsorted {

	public class IPausable : MonoBehaviour {
		public List<GameObject> gameObjects;
		public List<MonoBehaviour> scripts;

		public void OnPause() {
			foreach (GameObject gameObject in gameObjects) {
				foreach (MonoBehaviour script in gameObject.GetComponentsInChildren<MonoBehaviour>()) {
					script.enabled = false;
				}
			}

			foreach (MonoBehaviour script in scripts) {
				script.enabled = false;
			}
		}

		public void OnUnpause() {
			foreach (GameObject gameObject in gameObjects) {
				foreach (MonoBehaviour script in gameObject.GetComponentsInChildren<MonoBehaviour>()) {
					script.enabled = true;
				}
			}

			foreach (MonoBehaviour script in scripts) {
				script.enabled = true;
			}
		}
	}
}
