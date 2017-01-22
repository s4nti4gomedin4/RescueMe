using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {

	public delegate void AbilityManagerEvent(string abilityName);
	public static event AbilityManagerEvent abilityActive;

	//public List<GameObject> _abilities = new List<GameObject>();
	public Ability[] abilities;
	int indexAbility = 0;
	public Ability selectedAbility;

	// Use this for initialization
	void Start () {
		indexAbility = 0;
		//desactivate all abilities
		foreach (Ability ability in abilities) {
			ability.gameObject.SetActive (false);
			if (ability.abilityObject) {
				ability.abilityObject.SetActive (false);
			}
		}

	}


	public void UseSelectedAbility(){
		if (selectedAbility != null) {
			selectedAbility.UseAbility();
		}
	}

	public void NextAbility(bool ascending){
		if (selectedAbility != null) {
			selectedAbility.gameObject.SetActive (false);
			if (selectedAbility.abilityObject) {
				selectedAbility.abilityObject.SetActive (false);
			}
		}

		if (!ascending) {
			if (indexAbility <= 0) {
				indexAbility = abilities.Length - 1;
			} else {
				indexAbility--;
			}
		} else {
			if (indexAbility < (abilities.Length - 1)) {
				indexAbility++;
			} else {
				indexAbility = 0;
			}
		}
		selectedAbility = abilities [indexAbility];
		selectedAbility.gameObject.SetActive (true);

		if (abilityActive != null) {
			abilityActive (selectedAbility.abilityName);
		}

	}

}
