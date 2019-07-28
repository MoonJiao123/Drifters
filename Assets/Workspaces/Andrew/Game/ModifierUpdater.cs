using UnityEngine;

namespace Unsorted {

	public class ModifierUpdater : MonoBehaviour {

		#region MONOBEHAVIOUR
		void Awake() {
			GameState.Machine.AddStateAction(Level.BossA, () => GameState.HasBrain = true, Andtech.Automata.TransitionDirection.Exit);
			GameState.Machine.AddStateAction(Level.BossB, () => GameState.HasHeart = true, Andtech.Automata.TransitionDirection.Exit);
			GameState.Machine.AddStateAction(Level.BossC, () => GameState.HasCourage = true, Andtech.Automata.TransitionDirection.Exit);
		}
		#endregion MONOBEHAVIOUR
	}
}
