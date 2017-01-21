using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosions : MonoBehaviour {

	public GameObject explosionVfx;


	
	// Update is called once per frame
	IEnumerator Start () {
		while (true) {
			yield return new WaitForSeconds (2f);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 41), 0, Random.Range(-12, 15)), Quaternion.identity);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 41), 0, Random.Range(-12, 15)), Quaternion.identity);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 41), 0, Random.Range(-12, 15)), Quaternion.identity);
			Instantiate (explosionVfx, new Vector3(Random.Range(-24, 41), 0, Random.Range(-12, 15)), Quaternion.identity);
		}
	}
}
