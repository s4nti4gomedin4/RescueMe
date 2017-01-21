using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;

	AbilityManager abilityManager;


	public float playerSpeed;

	public float speed ;
	public float maxSpeed;
	private Vector3 prevPosition;

	//Movement2
	public float movementSpeed = 10;
	public float turningSpeed = 60;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		abilityManager = GetComponent<AbilityManager> ();
		prevPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Movement1 ();
		Movement2();





		loadSpeedMovement ();
	}
	public void Movement2(){
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);
	}
	public void loadSpeedMovement(){
		playerSpeed=Vector3.Distance(prevPosition,transform.position);
		prevPosition = transform.position;
	}

	public void Movement1(){
		float moveX = -Input.GetAxis ("Vertical");
		float moveZ = Input.GetAxis ("Horizontal");
		Vector3 forcePosition = new Vector3(moveX,0,moveZ)*speed; 
		Vector3 force = forcePosition + transform.position;






		if (Input.GetButtonDown ("Fire1")) {
			print ("Someone pressed something");
			if (abilityManager) {
				abilityManager.UseAbilityAtIndex (1);
			}
		}

		if (Input.GetButtonDown ("Jump")) {
			if (abilityManager) {
				abilityManager.NextAbility ();
			}
		}

		transform.LookAt (force);
		Vector3 newPosition = transform.position;
		newPosition += transform.forward *Mathf.Abs(moveX+moveZ);
		rb.MovePosition (newPosition);

	}
}
