using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestO  {

    public enum QuestProgress { NotAvailable, Available, Accepted, Complete, Done }

    public string title;
    public int id;
    public QuestProgress progress;
    public string description;
    public string hint;
    public string congratulation;
    public string summary;
    public int nextQuest;

    public string questObjective;
    public int questObjectiveCount;
    public int questObjectiveRequirement;

    public int expReward;
    public int goldReward;
    public string itemReward;
	
}
