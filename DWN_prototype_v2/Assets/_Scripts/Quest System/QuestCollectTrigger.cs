using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectTrigger : MonoBehaviour {
    //meant to be attached on a visible object
    public string itemTag;
    public int questNumber;
    private QuestManager QM;
    public QuestObject QO;
    public QuestTrigger EndQT;
    
    private void Start()
    {
        QM = FindObjectOfType<QuestManager>();

    }

    void Update () {
        
  

	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" )
        CollectTrigger();
    }

    public void CollectTrigger() {

            if (!QM.questCompleted[questNumber] && QM.activeQuest == questNumber)
            {

                gameObject.SetActive(false);
                QO.currentCount += 1;
                if (QO.CollectionComplete() && !QO.EndInstant)
                {

                    EndQT.gameObject.SetActive(true);
                }
            }
    
    }
    public void DestroyedTrigger() {
        if (!QM.questCompleted[questNumber] && QM.activeQuest == questNumber)
        {

            QO.currentCount += 1;
            if (QO.CollectionComplete() && !QO.EndInstant)
            {

                EndQT.gameObject.SetActive(true);
            }
        }



    }
}
