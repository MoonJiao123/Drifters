using UnityEngine;

namespace Unsorted {

	public class GameStateInputDebugger : MonoBehaviour {

		void Update() {
#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Keypad1))
				GameState.StartA();
			if (Input.GetKeyDown(KeyCode.Keypad2))
				GameState.StartB();
			if (Input.GetKeyDown(KeyCode.Keypad3))
				GameState.StartC();
			if (Input.GetKeyDown(KeyCode.Tab))
				GameState.NextLevel();
			if (Input.GetKeyDown(KeyCode.Escape))
				GameState.Win();
#endif
		}
	}
}
