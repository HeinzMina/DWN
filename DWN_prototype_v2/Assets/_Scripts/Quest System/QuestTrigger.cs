using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {
	
//	public static QuestTrigger questTrigger;

    private QuestManager QM;
    public int questNumber;
    public bool IsStartQuest;

//	void Awake(){
//		if (questTrigger == null) {
//			DontDestroyOnLoad (gameObject);
//			questTrigger = this;
//		}
//		else if (questTrigger != null) {
//			Destroy (gameObject);
//		}
//	}
 
	// Use this for initialization
	void Start () {
		QM = QuestManager.questManager; 
		//playercontroller = GetComponent<PlayerController1> ();
		//playeranimation = GetComponent<PlayerAnimation> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
        {
            if (!QM.questCompleted[questNumber])
            {
                if (IsStartQuest && !QM.quests[questNumber].gameObject.activeSelf)
                {
                    StartQuest();
					//this.gameObject.SetActive (false);
                }
               else if (!IsStartQuest && QM.quests[questNumber].gameObject.activeSelf) {
                    EndQuest();
					this.gameObject.SetActive (false);
					//playercontroller.enabled = false;
					//playeranimation.enabled = false;
                }
				//this.gameObject.SetActive (false);
				//playercontroller.enabled = true;
				//playeranimation.enabled = true;
            }
        }
	}

    void StartQuest() {
       if (checkChronologicalQuest())
       {
            QM.activeQuest = questNumber;
            QM.quests[questNumber].gameObject.SetActive(true);
            QM.quests[questNumber].StartQuest();
			this.gameObject.SetActive (false);
        }
    }
    void EndQuest() {
        QM.activeQuest = -1;
        QM.quests[questNumber].EndQuest();
    }


    private bool checkChronologicalQuest() {
        bool check = true;
        if (questNumber == 0) return true;

        for (int i = questNumber-1; i >=0; i--)
        {
            Debug.Log("checking quest " + i);
            if (QM.questCompleted[i] == false)
                check = false;
        }
		if (check) {
			//this.gameObject.SetActive (false);
			Debug.Log ("Quests before Quest " + questNumber + " is completed");
		}
		else {
			//this.gameObject.SetActive (false);
			Debug.Log ("Quests before Quest " + questNumber + " is NOT completed");
		}
        return check;
    }
}
