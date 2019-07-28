using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public int sceneIndex;
	public string sceneName;
    public AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
	{
        if (collider.gameObject.tag.Equals("Player")) {
			Debug.Log("TRIGGERED");
			ChangeScene(sceneName);
            sound.Play();
		}
     }

	public static void ChangeScene(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}

	public static void ChangeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
