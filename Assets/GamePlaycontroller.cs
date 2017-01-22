using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaycontroller : MonoBehaviour {

	public GameObject prefabVictim;
	public Transform playerPosition;
	public GameObject player;
	public Transform panelVictim;
	public Transform[] victimsPosition;


	void OnEnable(){
		GameController.restartGameEvent += RestartGame;
		GameController.stopGameEvent += StopGame;
	}
	void OnDisable(){
		GameController.restartGameEvent -= RestartGame;
		GameController.stopGameEvent -= StopGame;
	}
	public void RestartGame(){
		CreateVictims ();
		ResetPlayerPosition ();
	}
	public void StopGame(){
	}

	public void CreateVictims (){
		ClearVictims ();
		for (int i = 0; i < victimsPosition.Length; i++) {
			var newVictim = Instantiate (prefabVictim);
			newVictim.transform.SetParent (panelVictim.transform);
			newVictim.transform.position = victimsPosition [i].position;
		}

	}
	public void ClearVictims(){
		foreach (Transform trans in panelVictim) {
			Destroy (trans.gameObject);
		}
	}

	public void ResetPlayerPosition(){
		player.transform.position = playerPosition.position;
		player.transform.rotation = playerPosition.rotation;
	}
}
