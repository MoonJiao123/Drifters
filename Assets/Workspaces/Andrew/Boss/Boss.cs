using Andtech;
using System;
using UnityEngine;

namespace Unsorted {

	public class Boss : Singleton<Boss> {
		public static float Health = 100.0F;
		public static float MaxHealth = 100.0F;
		public static float HealthAsPercentage => Health / MaxHealth;
		public static float ArmorMultiplier = 0.0F;

		public static float DamageMultiplier = 100.0F;

		public static event EventHandler AddedHealth;
		public static event EventHandler TookDamage;
		public static event EventHandler Died;

		static Boss() {
			Current = new Boss();
		}

		public static void ApplyDamage(float damage) {
			Health -= damage;

			TookDamage?.Invoke(Current, EventArgs.Empty);

			if (Health.CompareTo(0.0F) < 0)
				Died?.Invoke(Current, EventArgs.Empty);
		}
	}
}
