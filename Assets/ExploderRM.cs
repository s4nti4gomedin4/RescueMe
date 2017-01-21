using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ExploderRM : Exploder {

	public virtual IEnumerator explode() {
		ExploderComponent[] components = GetComponents<ExploderComponent> (); 

		foreach (ExploderComponent component in components) {
			if (component.enabled) {
				component.onExplosionStarted (this);
			}
		}		
		while (explodeDuration > Time.time - explosionTime) {
			disableCollider ();
			for (int i = 0; i < probeCount; i++) {
				shootFromCurrentPosition ();
			}
			enableCollider ();
			yield return new WaitForFixedUpdate ();
		}
	}

	void FixedUpdate() {
		if (Time.time > explosionTime && !exploded) {
			exploded = true;
			StartCoroutine("explode");
		}
	}
}
