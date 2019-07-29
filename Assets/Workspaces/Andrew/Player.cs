using Andtech;
using System;
using UnityEngine;

namespace Unsorted {

	public class Player : Singleton<Player> {
		public static float Health = 100.0F;
		public static float MaxHealth = 100.0F;
		public static float HealthAsPercentage => Health / MaxHealth;
		public static float ArmorMultiplier = 1.0F;

		public static float DamageMultiplier = 100.0F;

		public static event EventHandler AddedHealth;
		public static event EventHandler TookDamage;
		public static event EventHandler Died;

		static Player() {
			Current = new Player();
		}

		public static void AddHealth(float amount) {
			Health = Mathf.Clamp(Health + amount, 0.0F, 100.0F);

			AddedHealth?.Invoke(Current, EventArgs.Empty);
		}

		public static void ApplyDamage(float damage) {
			Health -= damage * ArmorMultiplier;

			TookDamage?.Invoke(Current, EventArgs.Empty);

			if (Health.CompareTo(0.0F) < 0)
				Died?.Invoke(Current, EventArgs.Empty);
		}
	}
}
