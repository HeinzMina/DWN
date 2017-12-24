using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjectO : MonoBehaviour {

    private bool inTrigger = false;

    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    //public Shader shader;
    public Text questDescription;

	// Use this for initialization
	void Start () {
		SetQuestMarker();
	}
	
	// Update is called once per frame
	void Update () {

        if (inTrigger)
        {
            //quest ui manager
            SetQuestMarker();
            QuestManagerO.questManager.QuestRequest(this);
            inTrigger = false;
        }
	}

    void SetQuestMarker()
    {
        if (QuestManagerO.questManager.CheckAcceptedQuest(this))
        {
            questDescription.text = "You have quest";
        }
        else
        {
            questDescription.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
