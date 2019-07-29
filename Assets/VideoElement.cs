using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoElement : MonoBehaviour {
	[SerializeField]
	private RawImage rawImage;
	[SerializeField]
	private VideoPlayer videoPlayer;

	#region MONOBEHAVIOUR
	protected virtual void Reset() {
		videoPlayer = videoPlayer.GetComponent<VideoPlayer>();
	}

	protected virtual void OnEnable() {
		StartCoroutine(Preparing());
	}
	#endregion MONOBEHAVIOUR

	#region COROUTINE
	private IEnumerator Preparing() {
		videoPlayer.Prepare();
		while (!videoPlayer.isPrepared) {
			yield return null;
		}
		rawImage.texture = videoPlayer.texture;
		videoPlayer.Play();
	}
	#endregion COROUTINE
}
