using Andtech.Automata;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unsorted {

	[Serializable]
	public struct KVP {
		public Level level;
		public int buildIndex;
	}
	
	public class SceneController : MonoBehaviour {
		[SerializeField]
		private List<KVP> levels;

		public bool TryGetValue(Level level, out int buildIndex) {
			try {
				buildIndex = levels.First(x => x.level == level).buildIndex;

				return true;
			}
			catch {
				buildIndex = -1;
			}

			return false;
		}

		#region MONOBEHAVIOUR
		void Awake() {
			GameState.Machine.FinishedStep += UpdateLevel;
		}
		#endregion MONOBEHAVIOUR

		#region CALLBACK
		void UpdateLevel(object sender, EventArgs e) {
			bool success;
			
			success = GameState.Machine.TryGetPresentState(out Level level);
			if (!success)
				return;

			success = TryGetValue(level, out int buildIndex);
			if (!success)
				return;

			if (success)
				Debug.LogFormat("Go to level {0} (index {1})", level, buildIndex);

			SceneChange.ChangeScene(buildIndex);
		}
		#endregion CALLBACK
	}
}
