using UnityEngine;

namespace Unsorted {

	public class QuickMenuPlay : MonoBehaviour {

		public void Play() {
			InitializeGameState();

			SceneChange.ChangeScene(3);
		}

		void InitializeGameState() {
			GameState.HasBrain = false;
			GameState.HasHeart = false;
			GameState.HasCourage = false;
			Player.Health = 100.0F;
			Player.ArmorMultiplier = 1.0F;
			Player.DamageMultiplier = 1.0F;
			GameState.Play();
		}
	}
}
