using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {

	//public List<GameObject> _abilities = new List<GameObject>();
	public GameObject[] abilities;

	// Use this for initialization
	void Start () {
		foreach (GameObject ability in abilities) {
			ability.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseAbilityAtIndex(int abilityIndex){
		//Instantiate<GameObject> (ability, gameObject.transform.position, Quaternion.identity);
		//ability.SetActive(true);
		//print(Abilities.Length);
		abilities[abilityIndex].SetActive(true);
	}
}
