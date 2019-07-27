using UnityEngine;

namespace Unsorted {

	public class GameStateInputDebugger : MonoBehaviour {

		void Update() {
			if (Input.GetKeyDown(KeyCode.A))
				GameState.StartA();
			if (Input.GetKeyDown(KeyCode.B))
				GameState.StartB();
			if (Input.GetKeyDown(KeyCode.C))
				GameState.StartC();
			if (Input.GetKeyDown(KeyCode.Tab))
				GameState.NextLevel();
			if (Input.GetKeyDown(KeyCode.Escape))
				GameState.Win();
		}
	}
}
