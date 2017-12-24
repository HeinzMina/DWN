using UnityEngine;
using System.Collections;

public class PlayerController1Room : MonoBehaviour {

	//private Animator animator;
	public Transform playerCam, character, centerPoint;

	private float mouseX, mouseY;
	public float mouseSensitivity = 10f;
	public float mouseYPosition = 1f;

	private float moveFB, moveLR;
	public float moveSpeed = 6f;

	private float zoom;
	public float zoomSpeed = 2;

	public float zoomMin = -5f;
	public float zoomMax = -7f;

	public float rotationSpeed = 20f;

	//int currentState, WALK = 1, BACK = 2, IDLE = 0;

	// Use this for initialization
	void Start () {
	
		zoom = -5;
        
		//animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		zoom += Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;

		if (zoom > zoomMin)
			zoom = zoomMin;

		if (zoom < zoomMax)
			zoom = zoomMax;

		playerCam.transform.localPosition = new Vector3 (0, 0, zoom);

		if (Input.GetMouseButton (1)) {
			mouseX += Input.GetAxis ("Mouse X");
			mouseY -= Input.GetAxis ("Mouse Y");
		}

		mouseY = Mathf.Clamp (mouseY, -60f, 60f);
		playerCam.LookAt (centerPoint);
		centerPoint.localRotation = Quaternion.Euler (mouseY, mouseX, 0);

		moveFB = Input.GetAxis ("Vertical") * moveSpeed;
		//moveLR = Input.GetAxis ("Horizontal") * moveSpeed;

		Vector3 movement = new Vector3 (0, 0, moveFB);
		movement = character.rotation * movement;
		character.GetComponent<CharacterController> ().Move (movement * Time.deltaTime);
		centerPoint.position = new Vector3 (character.position.x, character.position.y + mouseYPosition + 1.8f, character.position.z);

		if (Input.GetAxis ("Vertical") > 0) {
            moveSpeed = 6f;
			Quaternion turnAngle = Quaternion.Euler (0, centerPoint.eulerAngles.y, 0);

			character.rotation = Quaternion.Slerp (character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

		}
        else if (Input.GetAxis("Vertical") < 0)
        {
            moveSpeed = 4f;
            Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);

            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }
		
		//if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 ) {
			
			//Quaternion turnAngle = Quaternion.Euler (0, centerPoint.eulerAngles.y, 0);
			
			//character.rotation = Quaternion.Slerp (character.rotation, turnAngle, rotationSpeed * Time.deltaTime);
		//}
	
	}
}