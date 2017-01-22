using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosions : MonoBehaviour {

	public GameObject explosionVfx;

	public delegate void Explosion (float shakeDuration, float shakeIntensity);
	public static event Explosion OnExplosion;
	public bool hayExplosion = false;

	
	// Update is called once per frame
	/*IEnumerator Start () {
		while (true) {
			yield return new WaitForSeconds (4f);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 9), 0, Random.Range(0, 15)), Quaternion.identity);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 9), 0, Random.Range(-12, 0)), Quaternion.identity);
			Instantiate (explosionVfx, new Vector3(Random.Range(9, 41), 0, Random.Range(-12, 0)), Quaternion.identity);

			if (OnExplosion != null) {
				OnExplosion (2.0f, 0.5f);
			}
		}
	}*/

	void Update(){
		if (!hayExplosion) {
			hayExplosion = true;
			Instantiate (explosionVfx, new Vector3 (Random.Range (9, 41), 0, Random.Range (-12, 0)), Quaternion.identity);
		
			if (OnExplosion != null) {
				OnExplosion (2.0f, 0.5f);
			}
		}
	}
}
