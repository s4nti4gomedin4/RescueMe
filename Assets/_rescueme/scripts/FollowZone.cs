﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZone : MonoBehaviour {

	public delegate void FollowZoneEvents();
	public static event FollowZoneEvents FollowingPlayer;
	public static event FollowZoneEvents victimSave;

	VictimController victim;

	// Use this for initialization
	void Start () {
		victim = transform.parent.GetComponent<VictimController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (victim) {
			if (other.CompareTag ("Bandage")) {
				victim.SetNewRescuer (other.gameObject);
				if (FollowingPlayer != null) {
					FollowingPlayer ();
				}
			} else if (other.CompareTag ("RescueZone")) {
				if (victimSave != null) {
					victimSave ();
				}
				Destroy (transform.parent.gameObject);
			}
		}
	}
}
