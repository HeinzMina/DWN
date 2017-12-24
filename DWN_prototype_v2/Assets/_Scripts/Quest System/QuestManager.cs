using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public static QuestManager questManager;
	//public static DialogueManager dialogueManager;

    public QuestObject[] quests;
    public bool[] questCompleted;
	private DialogueManager DM;
 	public int activeQuest;

	void Awake(){
		if (questManager == null) { // && dialogueManager == null) {
			DontDestroyOnLoad (gameObject);
			questManager = this;
			//dialogueManager = this;
		}
		else if (questManager != this) { // && dialogueManager != null) {
			Destroy (gameObject);
		}
	}

    // Use this for initialization
    void Start () {
		DM = DialogueManager.dialogueManager;
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowStartDialogue(Dialogue dialogue)
	{
       DM.StartDialogue(dialogue);
    }

	public void ShowEndDialogue(Dialogue dialogue)
    {
        DM.StartDialogue(dialogue);
    }


}
