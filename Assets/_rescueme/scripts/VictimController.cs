﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimController : MonoBehaviour {

	BoxCollider myCollider;
	public float speed = 0.1f;
	public float searchRadius = 3f;
	Rigidbody rb;
	public Animator m_animator;
	public bool isFollowing;
	GameObject rescuer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rescuer) {
			gameObject.transform.LookAt (rescuer.transform);
			float distance = Vector3.Distance (rescuer.transform.position, gameObject.transform.position);
			if (distance > searchRadius) {
				Vector3 newPosition = transform.forward * speed * Time.deltaTime;
				Vector3 force = newPosition + transform.position;
				force.y = transform.position.y;
				rb.MovePosition (force);
				isFollowing = true;
			}
		} else {
			isFollowing = false;
		}
		m_animator.SetBool ("following",isFollowing);
	}

	public void SetNewRescuer(GameObject newRescuer){
		rescuer = newRescuer;
	}
}
