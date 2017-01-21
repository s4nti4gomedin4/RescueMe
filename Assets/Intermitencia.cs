using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermitencia : MonoBehaviour {
	public Light luzintermitente;
	public float duration = 4.0F;
	public float minValue=1.3f;
	public float maxValue=4.9f;
	// Use this for initialization
	void Start () {
		luzintermitente = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude =Mathf.Lerp(minValue,maxValue,Mathf.Cos(phi) * 0.5F + 0.5F);

		luzintermitente.intensity = amplitude;
	}
}
