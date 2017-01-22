using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public delegate  void  GameControllerEvents();
	public static event GameControllerEvents restartGameEvent;
	public static event GameControllerEvents stopGameEvent;


	public TimerRescue m_TimerRescue;
	public RescueUI m_RescueUI;
	public GameObject endMessage;
	public GameObject textWin;
	public GameObject textLose;
	public GameObject objectStart;
	public static int maxVictimToWin=5;

	void OnEnable(){
		TimerRescue.timeEnd += LoseGame;
		RescueUI.allVictimsRescued += WinGame;
	}
	void OnDisable(){
		TimerRescue.timeEnd -= LoseGame;
		RescueUI.allVictimsRescued -= WinGame;
	}
	void Start(){
		OnStart ();
	}
	private void OnStart(){
		objectStart.SetActive (true);
		textWin.SetActive (false);
		textLose.SetActive (false);
		endMessage.SetActive (true);
	}
	public void OnPlay(){
		print ("OnPlay");
		RestartGame ();
	}
	public void RestartGame(){
		m_TimerRescue.timerOn = true;
		m_TimerRescue.timeElapse = 0;
		m_TimerRescue.seismographActiveState = 0;
		endMessage.SetActive (false);
		m_RescueUI.rescue = 0;
		if (restartGameEvent != null) {
			restartGameEvent ();
		}
	}
	public void StopGame(){
		m_TimerRescue.timerOn = false;
		if (stopGameEvent != null) {
			stopGameEvent ();
		}
	}

	public void WinGame(){
		endMessage.SetActive (true);
		textWin.SetActive (true);
		objectStart.SetActive (false);
		textLose.SetActive (false);
		StopGame ();
	}
	public void LoseGame(){
		endMessage.SetActive (true);
		textWin.SetActive (false);
		objectStart.SetActive (false);
		textLose.SetActive (true);
		StopGame ();

	}
}
