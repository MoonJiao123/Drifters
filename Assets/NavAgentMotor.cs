using UnityEngine;
using UnityEngine.AI;

namespace Unsorted {

	public class NavAgentMotor : MonoBehaviour {
		public float refreshRate;
		public Transform target;
		public NavMeshAgent agent;

		void Refresh() {
			agent.SetDestination(target.position);
		}

		#region MONOBEHAVIOUR
		void OnEnable() {
			InvokeRepeating("Refresh", 0.0F, refreshRate);
		}

		void OnDisable() {
			CancelInvoke();
		}
		#endregion MONOBEHAVIOUR
	}
}
