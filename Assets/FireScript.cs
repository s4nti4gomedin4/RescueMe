using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	public float fireHealth;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damage){
		fireHealth--;
		print ("Ouchies");
		if (fireHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
