﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	public float speed ;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Vertical");
		float moveZ = -Input.GetAxis ("Horizontal");
		Vector3 forcePosition = new Vector3(moveX,0,moveZ)*speed; 
		Vector3 force = forcePosition + transform.position;
		rb.MovePosition (force);
		transform.LookAt (force);
		
	}
}
