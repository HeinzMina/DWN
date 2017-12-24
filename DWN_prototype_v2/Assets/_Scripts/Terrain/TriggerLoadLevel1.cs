using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadLevel1 : MonoBehaviour {

	public GameObject panelUnhide;
	public GameObject panelHide;
	
	void Start()
    {
        panelUnhide.SetActive(false);
		panelHide.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
		{
			panelUnhide.SetActive(true);
			panelHide.SetActive(false);
		}
    }

    void OnTriggerExit()
    {
        panelUnhide.SetActive(false);
		panelHide.SetActive(true);
    }
}
