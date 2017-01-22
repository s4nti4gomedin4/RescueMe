using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incendios : MonoBehaviour {

	public GameObject llamaVfx;

	private bool hayIncendio = true;

	void OnEnable(){
		TimerRescue.seismographActiveEvent += generarIncendio;;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hayIncendio) {
			hayIncendio = true;

			Instantiate (llamaVfx, new Vector3 (Random.Range (-24, 9), 0, Random.Range (0, 15)), Quaternion.identity);
			Instantiate (llamaVfx, new Vector3 (Random.Range (-24, 9), 0, Random.Range (-12, 0)), Quaternion.identity);
			Instantiate (llamaVfx, new Vector3 (Random.Range (9, 41), 0, Random.Range (-12, 0)), Quaternion.identity);
			Instantiate (llamaVfx, new Vector3 (Random.Range (-24, 9), 0, Random.Range (0, 15)), Quaternion.identity);
			Instantiate (llamaVfx, new Vector3 (Random.Range (-24, 9), 0, Random.Range (-12, 0)), Quaternion.identity);
			Instantiate (llamaVfx, new Vector3 (Random.Range (9, 41), 0, Random.Range (-12, 0)), Quaternion.identity);
		}
	}

	public void generarIncendio(){
		hayIncendio = false;
	}
}
