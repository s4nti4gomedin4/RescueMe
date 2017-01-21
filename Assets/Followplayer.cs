using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour {

	public GameObject target;
	public float rotationDamping = 1;
	public float movementDamping = 3;
	public Walls lastWall;
	public Material transparentMaterial;
	Vector3 offset;

	void Start() {
		offset = target.transform.InverseTransformPoint(transform.position);
	}

	void LateUpdate() {
		Vector3 directiontoPlayer = target.transform.position - transform.position;
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
		if (distance > 1f) {
			if(Physics.Raycast(transform.position, directiontoPlayer, out hit, distance)) {
				//print ("name: "+hit.collider.gameObject.name);
				if (!hit.collider.gameObject.CompareTag ("Player")) {
					Walls wall = hit.collider.gameObject.GetComponent<Walls> ();
					if (wall != null) {
						ResetLastWallMaterial();
						wall.setMaterial (transparentMaterial);
						//SetAphaValue(wall.gameObject,0);
						lastWall = wall;
					}
				}else{
					ResetLastWallMaterial();
				}
			}
		}

	}
	public void ResetLastWallMaterial(){
		if(lastWall!=null){
			lastWall.setOriginalMaterial ();
			//SetAphaValue(lastWall.gameObject,1);
		}
	}
	public void SetAphaValue(GameObject objectAlpha,float alphaValue){
		Color originalColor=objectAlpha.GetComponent<Renderer> ().material.color;
		originalColor.a = alphaValue;
		objectAlpha.GetComponent<Renderer> ().material.color=originalColor;
	}
}
