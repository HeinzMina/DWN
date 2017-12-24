using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //public GameObject player;

    //private Vector3 offset;

	// Use this for initialization
	//void Start () {
        //offset = transform.position - player.transform.position;
	//}
	
	// Update is called once per frame
	//void LateUpdate () {
        //transform.position = player.transform.position + offset;
	//}

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private Space offsetSpace = Space.Self;

    [SerializeField]
    private bool lookat = true;

    void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (player == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;
        }

        // compute rotation
        if (lookat)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }
    }
}
