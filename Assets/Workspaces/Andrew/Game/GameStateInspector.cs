using UnityEngine;

namespace Unsorted {

	public class GameStateInspector : MonoBehaviour {
		public int bossDefeatCount;
		public string state;

		void Update() {
			bossDefeatCount = GameState.BossDefeatCount;
			state = GameState.CurrentLevel.ToString();
		}
	}
}
