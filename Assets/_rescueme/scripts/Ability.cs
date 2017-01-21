using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour {

	public delegate void AbilityEvents(string abilityName);
	public static event AbilityEvents usingAbility;

	public float cooldown;
	public bool canBeUsed;
	public string abilityName;


	// Use this for initialization
	void Start () {
		canBeUsed = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ResetCooldown(){
		canBeUsed = true;
	}

	public virtual void UseAbility(){
		// The hero uses an ability. Each one has a different behavior.
		if (canBeUsed) {
			print ("object can be used");
			Invoke ("ResetCooldown", cooldown);
			if (usingAbility != null) {
				usingAbility (abilityName);
			}
		} else {
			print ("ability is on cooldown");
		}
	}
}
