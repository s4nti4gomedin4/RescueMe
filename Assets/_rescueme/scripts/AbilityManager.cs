using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {

	//public List<GameObject> _abilities = new List<GameObject>();
	public Ability[] abilities;
	int selectedAbility = 0;

	// Use this for initialization
	void Start () {
		foreach (Ability ability in abilities) {
			ability.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseSelectedAbility(){
		abilities[selectedAbility].UseAbility();
	}

	public void NextAbility(bool ascending){
		abilities [selectedAbility].gameObject.SetActive (false);
		if (!ascending) {
			if (selectedAbility <= 0) {
				selectedAbility = abilities.Length - 1;
			} else {
				selectedAbility--;
			}
		} else {
			if (selectedAbility < (abilities.Length - 1)) {
				selectedAbility++;
			} else {
				selectedAbility = 0;
			}
		}
		abilities [selectedAbility].gameObject.SetActive (true);
	}

}
