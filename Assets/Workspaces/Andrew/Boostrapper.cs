using UnityEngine;

namespace Andrew {

	public class Boostrapper : MonoBehaviour {
		[SerializeField]
		private GameObject persistent = default;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			DontDestroyOnLoad(persistent);

			SceneChange.ChangeScene(1);
		}
        #endregion MONOBEHAVIOUR
	}
}
