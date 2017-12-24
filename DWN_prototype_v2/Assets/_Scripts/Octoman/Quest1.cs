using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour {
	public Image loading;
	public int QuestID;
	public float Total = 10;
    float timeAmt = 0;
    float time;

    //public GameObject triggerSample;

    public Text text;

    void Start()
    {
        time = timeAmt;
        //triggerSample.SetActive(false);
        
    }

    void Update()
    {
		if (time < Total)
        {
            time += Time.deltaTime;
            text.text = "" + time;
			loading.fillAmount = time / Total;
        }
        else
        {
            QuestManagerO.questManager.AddQuestItem("Attend orientation 1", 1);
            Application.LoadLevel(4);
        }
    }
}
