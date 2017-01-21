using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAbility : Ability {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UseAbility(){
		base.UseAbility ();
		if (canBeUsed) {
			print ("The hammer ability was used");
			canBeUsed = false;
		}
	}

}
