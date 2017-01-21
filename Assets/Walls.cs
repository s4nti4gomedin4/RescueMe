using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	private Material origialMaterial;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend=GetComponent<Renderer>();
		origialMaterial = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setOriginalMaterial(){
		rend.material = origialMaterial;
	}
	public void setMaterial(Material mat){
		rend.material = mat;
	}
}
