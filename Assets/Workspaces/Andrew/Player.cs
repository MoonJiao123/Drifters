using Andtech;
using System;

namespace Unsorted {

	public class Player : Singleton<Player> {
		public static float Health = 100.0F;
		public static float HealthAsPercentage => Health / 100.0F;
		public static float Armor = 0.0F;

		public static float Damage = 100.0F;

		public static event EventHandler AddedHealth;
		public static event EventHandler TookDamage;

		static Player() {
			Current = new Player();
		}

		public static void ApplyDamage(float damage) {
			Health -= damage;

			TookDamage?.Invoke(Current, EventArgs.Empty);
		}
	}
}
