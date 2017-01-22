using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaycontroller : MonoBehaviour {


	public delegate void GamePlaycontrollerEvents (int index,Vector3 position);
	public static event GamePlaycontrollerEvents helpVictim;
	public static event GamePlaycontrollerEvents ambientSound;

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
		CancelInvoke ();
		CreateVictims ();
		ResetPlayerPosition ();
		PlayRandomHelp ();
		PlayRandomAmbientSound();

	}
	public void StopGame(){
		StopAllCoroutines ();
	}
	public void PlayRandomHelp(){
		int helpInex = Random.Range (1, 5);
		int victimToHelp = Random.Range (0, victimsPosition.Length);
		if (helpVictim != null) {
			helpVictim(helpInex,victimsPosition[victimToHelp].position);
		}
		Invoke("PlayRandomHelp",5);
	}
	public void PlayRandomAmbientSound(){
		int randomSoundIndex = Random.Range (1,6);
		Vector3 randomPsotion = new Vector3 (Random.Range(-40,40),0,Random.Range(-40,40));
		if (ambientSound != null) {
			ambientSound (randomSoundIndex,randomPsotion);
		}
		Invoke("PlayRandomAmbientSound",Random.Range(3,10));
	}

	public void CreateVictims (){
		ClearVictims ();
		for (int i = 0; i < victimsPosition.Length; i++) {
			var newVictim = Instantiate (prefabVictim);
			newVictim.transform.SetParent (panelVictim.transform);
			newVictim.transform.position = victimsPosition [i].position;
			newVictim.transform.rotation = victimsPosition [i].rotation;
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
