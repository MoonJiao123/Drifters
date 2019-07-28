using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unsorted {

	public class ModifierSymboles : MonoBehaviour {
		public List<Graphic> graphics;

		#region MONOBEHAVIOUR
		void Update() {
			UpdateIcons();
		}
		#endregion MONOBEHAVIOUR

		void UpdateIcons() {
			graphics[0].enabled = GameState.HasBrain;
			graphics[1].enabled = GameState.HasHeart;
			graphics[2].enabled = GameState.HasCourage;
		}
	}
}
