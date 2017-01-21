using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	public float speed ;
	public float maxSpeed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Vertical");
		float moveZ = -Input.GetAxis ("Horizontal");
		//print ("moveX: "+moveX+" moveZ"+moveZ);
		Vector3 forcePosition = new Vector3(moveX,0,moveZ)*speed; 
		Vector3 force = forcePosition + transform.position;
		//var angle = Mathf.Atan2 (force.x,force.z)*Mathf.Rad2Deg;
		//Vector3 eulerAngleVelocity = new Vector3 (0, angle, 0);
		//var deltaRotation = Quaternion.Euler (eulerAngleVelocity*Time.deltaTime);
		//rb.MoveRotation (deltaRotation);
		rb.MovePosition (force);
		transform.LookAt (force);
		
	}
}
