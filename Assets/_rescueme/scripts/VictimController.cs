using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimController : MonoBehaviour {

	BoxCollider myCollider;
	public float speed = 4f;
	public float searchRadius = 2f;

	GameObject rescuer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rescuer) {
			gameObject.transform.LookAt (rescuer.transform);
			float distance = Vector3.Distance (rescuer.transform.position, gameObject.transform.position);
			if (distance > searchRadius) {
				gameObject.transform.position += transform.forward * Time.deltaTime * speed;
			}
		}
	}

	public void SetNewRescuer(GameObject newRescuer){
		rescuer = newRescuer;
	}
}
