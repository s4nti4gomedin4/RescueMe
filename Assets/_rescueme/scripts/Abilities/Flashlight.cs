using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Ability {

	public GameObject light_;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void UseAbility(){
		base.UseAbility ();
		if (canBeUsed) {
			print ("Used the flashlight");
			light_.SetActive (!light_.activeInHierarchy);
			canBeUsed = false;
		}
	}
}
