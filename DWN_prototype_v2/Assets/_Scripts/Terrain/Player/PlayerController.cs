using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    public float speed = 1.0f;
    public float rotationSpeed = 75.0f;
    private bool isRunning;
    int currentState, WALK = 1, BACK = 2, IDLE = 0, RUN = 3;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        CharacterController controller = gameObject.GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
           
            if (translation > 0)
            {
                animator.SetInteger("BoyState", WALK);
            }
            else if (translation < 0)
            {
                animator.SetInteger("BoyState", BACK);
            }
            else if (translation == 0)
            {
                animator.SetInteger("BoyState", IDLE);
            }
        }

	}
}
