using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public delegate void PlayerControllerEvents();
	public static event  PlayerControllerEvents playerStop;
	public static event  PlayerControllerEvents playerMove;
	public static event  PlayerControllerEvents playerChangeAbility;


	Rigidbody rb;

	AbilityManager abilityManager;

	public Animator animator;
	public float playerSpeed;
	private Vector3 prevPosition;

	//Movement2
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	public bool playing;


	void OnEnable(){
		GameController.restartGameEvent += RestartGame;
		GameController.stopGameEvent += StopGame;
	}
	void OnDisable(){
		GameController.restartGameEvent -= RestartGame;
		GameController.stopGameEvent -= StopGame;
	}

	void RestartGame(){
		playing = true;
	}
	void StopGame(){
		playing = false;
	}


	// Use this for initialization
	void Start () {
		playing = false;
		rb = GetComponent<Rigidbody> ();
		abilityManager = GetComponent<AbilityManager> ();
		prevPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!playing) {
			return;
		}
		Movement2();
		CheckAbility ();
		loadSpeedMovement ();
		playerSpeed=Mathf.Abs( Input.GetAxis("Vertical"));
		animator.SetFloat ("speed",playerSpeed);
		if (playerSpeed == 0) {
			if (playerStop != null) {
				playerStop ();
			}

		} else {
			if (playerMove != null) {
				playerMove ();
			}
		}


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


	public void CheckAbility(){
		if (Input.GetButtonDown ("Fire1")) {
			if (abilityManager) {
				abilityManager.UseSelectedAbility ();
			}
		}

		if (Input.GetButtonDown ("SwitchLeft")) {
			if (abilityManager) {
				if (playerChangeAbility!=null) {
					playerChangeAbility ();
				}

				abilityManager.NextAbility (false);
			}
		}

		if (Input.GetButtonDown ("SwitchRight")) {
			if (abilityManager) {
				if (playerChangeAbility!=null) {
					playerChangeAbility ();
				}
				abilityManager.NextAbility (true);
			}
		}

	}
}
