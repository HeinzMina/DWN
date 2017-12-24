using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
public class QuestObject : MonoBehaviour {
    public int questNumber;
    public QuestManager QM;

    public string Title;
    [TextArea(3, 5)]
    public string Description;


    public bool IsCollection;
    public bool EndInstant;
    public string itemTag;
    public int currentCount = 0;
    public int required;
    public QuestTrigger EndQuestTrigger;
	public Dialogue startDialogue;
	public Dialogue endDialogue;

    public delegate void QuestStarted();
    public static event QuestStarted OnQuestStart;

    public delegate void QuestEnded();
    public static event QuestEnded OnQuestEnd;


    //public TextMeshProUGUI titleText;

    // Use this for initialization
    void Start () {
     //   titleText.text = "";
  
    }
	
	// Update is called once per frame
	void Update () {
        if(IsCollection)
        if (currentCount >= required)
        {
            if (EndInstant)
            {
                QM.activeQuest = -1;
                QM.quests[questNumber].EndQuest();
                EndQuest();
            }
        

        }
    }

    public void StartQuest() {
        if (OnQuestStart != null)
            OnQuestStart();
        QM.ShowStartDialogue(startDialogue);
        if (IsCollection)
        {//initialize collection here
            //Debug.Log("Initializing Collectibles" + questNumber);
            //GameObject collectibleHandler = GameObject.FindGameObjectWithTag("Collectibles" + questNumber);
            //Transform[] transforms = collectibleHandler.GetComponentsInChildren<Transform>();
            //List<GameObject> collectibles = new List<GameObject>();
            //foreach (var t in transforms)
            //{
            //    collectibles.Add(t.gameObject);
            //}
            //Debug.Log(collectibles.Count + " collectible(s) found");
            //foreach (GameObject collect in collectibles)
            //{
            //    collect.SetActive(true);
            //}
            
            if (!EndInstant)
            {
                

                EndQuestTrigger.gameObject.SetActive(false);
            }
        }
        
      //  titleText.text = Title;

     //   Debug.Log(titleText.text);
    }

    public void EndQuest()
    {   
        // titleText.text = "";
        if (OnQuestEnd != null)
            OnQuestEnd();

        QM.ShowEndDialogue(endDialogue);
        QM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);

    }

    public bool CollectionComplete() {
           bool check;
            if (currentCount >= required)
                check = true;
            else check = false;
            return check;
  
    }
}
