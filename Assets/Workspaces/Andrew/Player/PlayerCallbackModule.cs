using System;
using UnityEngine;

namespace Unsorted {

	public class PlayerCallbackModule : MonoBehaviour {

		void Awake() {
			Player.Died += HandleDeath;
		}

		void OnDestroy() {
			Player.Died -= HandleDeath;
		}

		void HandleDeath(object sender, EventArgs e) {
			SceneChange.ChangeScene(0);
		}
	}
}
