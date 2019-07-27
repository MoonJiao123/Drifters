using UnityEngine;

namespace Unsorted {

	public class GameStateInspector : MonoBehaviour {
		public int bossDefeatCount;
		public Level level;

		void Update() {
			bossDefeatCount = GameState.BossDefeatCount;
			level = GameState.CurrentLevel;
		}
	}
}
