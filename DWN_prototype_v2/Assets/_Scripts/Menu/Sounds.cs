using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onHover()
    {
        source.PlayOneShot(hover);
    }

    public void onClick()
    {
        source.PlayOneShot(click);
    }
}
