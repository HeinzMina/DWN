using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animator animator;
	
	int currentState, WALK = 1, BACK = 2, IDLE = 0, RIGHT = 4, LEFT = 5;
	
	void Start () {
	
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow)) {
			
			animator.SetInteger("BoyState", WALK);
			
		}
		
		else if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow)) {
			
			animator.SetInteger("BoyState", BACK);
			
		}
		
		else if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow)) {
			
			animator.SetInteger("BoyState", LEFT);
			
		}
		
		else if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow)) {
			
			animator.SetInteger("BoyState", RIGHT);
			
		}
		
		else if (Input.GetAxis ("Vertical") == 0) { //&& Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.D)
			
			animator.SetInteger("BoyState", IDLE);
			
		}
	}
}