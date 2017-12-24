using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManagerO : MonoBehaviour {

    public static QuestManagerO questManager;

    public List <QuestO> questList = new List<QuestO>();
    public List<QuestO> currentQuestList = new List<QuestO>();

    //private vars for our QuestObject

    void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void QuestRequest(QuestObjectO NPCQuestObject)
    {
        //Check Available Quest
        if (NPCQuestObject.availableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
                {
                    if (questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == QuestO.QuestProgress.Available)
                    {
                        Debug.Log("Quest ID : " + NPCQuestObject.availableQuestIDs[j] + " " + questList[i].progress);
                        //TESTING
                        AcceptQuest(NPCQuestObject.availableQuestIDs[j]);

                        //quest ui manager
                    }
                }
            }
        }

        //Check Active Quest
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (currentQuestList[i].id == NPCQuestObject.receivableQuestIDs[j] && currentQuestList[i].progress == QuestO.QuestProgress.Accepted || currentQuestList[i].progress == QuestO.QuestProgress.Complete)
                {
                    Debug.Log("Quest ID: " + NPCQuestObject.receivableQuestIDs[j] + " is " + currentQuestList[i].progress);
                    //quest ui manager

                    CompleteQuest(NPCQuestObject.receivableQuestIDs[j]);
                }
            }
        }
    }
    
    //Accept Quest

    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestO.QuestProgress.Available)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = QuestO.QuestProgress.Accepted;
            }
        }
    }

    //Give up

    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == QuestO.QuestProgress.Accepted)
            {
                currentQuestList[i].progress = QuestO.QuestProgress.Available;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    //Complete Quest

    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == QuestO.QuestProgress.Complete)
            {
                currentQuestList[i].progress = QuestO.QuestProgress.Done;
                currentQuestList.Remove(currentQuestList[i]);

                //Reward
            }
        }

        //check for chain quests
        CheckChainQuest(questID);
    }

    //Check Chain Quest

    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].nextQuest > 0)
            {
                tempID = questList[i].nextQuest;
            }
        }

        if (tempID > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                if (questList[i].id == tempID && questList[i].progress == QuestO.QuestProgress.NotAvailable)
                {
                    questList[i].progress = QuestO.QuestProgress.Available;
                }
            }
        }
    }

    //Add Items

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == QuestO.QuestProgress.Accepted)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progress == QuestO.QuestProgress.Accepted)
            {
                currentQuestList[i].progress = QuestO.QuestProgress.Complete;
            }
        }
    }

    //Remove Items

	// Bools

    public bool RequestAvailableQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID &&  questList[i].progress == QuestO.QuestProgress.Available)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestO.QuestProgress.Accepted)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == QuestO.QuestProgress.Complete)
            {
                return true;
            }
        }
        return false;
    }

    //Bools 2

    public bool CheckAvailableQuest(QuestObjectO NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.availableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.availableQuestIDs[j] && questList[i].progress == QuestO.QuestProgress.Available)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckAcceptedQuest(QuestObjectO NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == QuestO.QuestProgress.Accepted)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCompletedQuest(QuestObjectO NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQuestIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQuestIDs[j] && questList[i].progress == QuestO.QuestProgress.Complete)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
