using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public Transition transition;
    public AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
	{
        if (collider.gameObject.tag.Equals("Player")) {
			switch (transition) {
				case Transition.StartA:
					GameState.StartA();
					break;
				case Transition.StartB:
					GameState.StartB();
					break;
				case Transition.StartC:
					GameState.StartC();
					break;
				case Transition.Next:
					GameState.NextLevel();
					break;
				case Transition.Win:
					GameState.Win();
					break;
			}

			Debug.Log("TRIGGERED");
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
