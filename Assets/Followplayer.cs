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
	}
}
