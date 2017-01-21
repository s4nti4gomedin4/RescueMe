using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HammerTime(){
		// Destroys the object and does something else.

		Destroy(transform.parent.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Hammer")) {
			HammerTime ();
		}
	}
}
