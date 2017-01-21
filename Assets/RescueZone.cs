using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueZone : MonoBehaviour {

	public delegate void RescueZoneEvents (GameObject victim);
	public static event RescueZoneEvents victimRescue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Victim")) {
			if (victimRescue != null) {
				victimRescue (other.gameObject);
			}
		}
	}
}
