using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguiserAbility : Ability {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void UseAbility(){
		base.UseAbility ();
		if (canBeUsed) {
			print ("Used the extinguiser");
			RaycastHit hit;
			Vector3 dir = transform.parent.forward;

			Physics.Raycast (transform.parent.position, dir, out hit, 5);
			if (hit.collider) {
				if (hit.collider.CompareTag ("FlamableObject")) {
					hit.collider.GetComponent<FireScript>().TakeDamage(1);
				}
			}

			canBeUsed = false;
		}

	}
}
