using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour {

	public GameObject target;
	public float rotationDamping = 1;
	public float movementDamping = 3;
	Vector3 offset;

	void Start() {
		offset = target.transform.InverseTransformPoint(transform.position);
	}

	void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rot = transform.rotation;
		rot.eulerAngles = new Vector3(0, Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * rotationDamping), 0);
		transform.rotation = rot;
		Vector3 desiredPosition = target.transform.TransformPoint(offset);
		transform.position = Vector3.Lerp (transform.position, desiredPosition, Time.deltaTime * movementDamping); 

		//Quaternion rotation = Quaternion.Euler(0, angle, 0);
		//transform.position = target.transform.position - (rotation * offset);
		//transform.LookAt(target.transform);

		/*
          * Create the hit object.
          */
		RaycastHit hit;
		/*
          * Cast a Raycast.
          * If it hits something:
          */

		float distance = Vector3.Distance (transform.position,target.transform.position);
		Debug.DrawRay (transform.position,target.transform.position.normalized);
		if(Physics.Raycast(transform.position, target.transform.position.normalized, out hit, distance)) {
			/*
              * Set the target location to the location of the hit.
              */

			print ("name: "+hit.collider.gameObject.name);
			/*
              * Modify the target location so that the object is being perfectly aligned with the ground (if it's flat).
              */
			//targetLocation += new Vector3(0, transform.localScale.y / 2, 0);
			/*
              * Move the object to the target location.
              */
			//transform.position = targetLocation;
		}
	

	}
}
