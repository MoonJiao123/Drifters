using Andtech;
using System;

namespace Unsorted {

	public class Player : Singleton<Player> {
		public static float Health = 100.0F;
		public static float HealthAsPercentage => Health / 100.0F;
		public static float ArmorMultiplier = 0.0F;

		public static float DamageMultiplier = 100.0F;

		public static event EventHandler AddedHealth;
		public static event EventHandler TookDamage;
		public static event EventHandler Died;

		static Player() {
			Current = new Player();
		}

		public static void ApplyDamage(float damage) {
			Health -= damage;

			TookDamage?.Invoke(Current, EventArgs.Empty);

			if (Health.CompareTo(0.0F) < 0)
				Died?.Invoke(Current, EventArgs.Empty);
		}
	}
}
