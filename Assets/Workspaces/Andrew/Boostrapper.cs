using UnityEngine;

namespace Andrew {

	public class Boostrapper : MonoBehaviour {
		[SerializeField]
		private GameObject persistent = default;
		[SerializeField]
		private int buildIndexNext;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			DontDestroyOnLoad(persistent);

			SceneChange.ChangeScene(buildIndexNext);
		}
        #endregion MONOBEHAVIOUR
	}
}
