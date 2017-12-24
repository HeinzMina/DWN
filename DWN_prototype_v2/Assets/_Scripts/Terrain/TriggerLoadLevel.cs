using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadLevel : MonoBehaviour {

	public GameObject panelBtn;
	
	void Start()
    {
        panelBtn.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
		{
			panelBtn.SetActive(true);
		}
    }

    void OnTriggerExit()
    {
        panelBtn.SetActive(false);
    }
}
