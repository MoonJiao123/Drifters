using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unsorted;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Animator dialogueAnime, startButtor, nextButtor;

    private Queue<string> conversation;

    void Start() {
		foreach (IPausable pausable in FindObjectsOfType<IPausable>()) {
			pausable.OnPause();
		}

		conversation = new Queue<string>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key or mouse click has been detected");
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        startButtor.SetBool("isEnd", false);
        dialogueAnime.SetBool("isOpen", true);
        nextButtor.SetBool("isEnd", false);
        conversation.Clear();
        foreach(string s in dialogue.sentences)
        {
                conversation.Enqueue(s);
        }
        startButtor.SetBool("isEnd", true);
        DisplayNextSentence();
    }

    
    public void DisplayNextSentence()
    {
        if(conversation.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string s = conversation.Dequeue();
        dialogueText.text = s;
        Console.WriteLine();
    }
    void EndDialogue() {
		foreach (IPausable pausable in FindObjectsOfType<IPausable>()) {
			pausable.OnUnpause();
		}

		dialogueAnime.SetBool("isOpen", false);
        nextButtor.SetBool("isEnd", true);
		//Debug.Log("end");
    }
}
