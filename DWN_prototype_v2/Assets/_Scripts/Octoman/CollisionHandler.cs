using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    public int sceneToLoad;
    //public string spawnPointName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //QuestManagerO.questManager.AddQuestItem("Attend orientation 1", 1);
        Application.LoadLevel(sceneToLoad);
    }
}
