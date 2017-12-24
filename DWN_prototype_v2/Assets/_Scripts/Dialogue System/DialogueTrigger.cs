using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	
	//public GameObject dialoguebox;

	public void TriggerDialogue ()
	{
		//dialoguebox.SetActive(true);
		
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}