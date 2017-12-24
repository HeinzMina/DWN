using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour {

	public static Canvas canvas;

	//private PlayerController1 Pc;

	void Awake(){
		if (canvas == null) { // && dialogueManager == null) {
			DontDestroyOnLoad (gameObject);
			canvas = this;
			//dialogueManager = this;
		}
		else if (canvas != this) { // && dialogueManager != null) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		//Pc = FindObjectOfType<PlayerController1> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
