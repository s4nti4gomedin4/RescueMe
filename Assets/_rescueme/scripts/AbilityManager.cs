using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {

	public GameObject ability;
	public GameObject hammer;


	// Use this for initialization
	void Start () {
		ability.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UseAbility(){
		//Instantiate<GameObject> (ability, gameObject.transform.position, Quaternion.identity);
		ability.SetActive(true);
	}
}
