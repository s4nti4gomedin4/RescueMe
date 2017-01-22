using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

	public delegate  void  GameControllerEvents();
	public static event GameControllerEvents restartGameEvent;
	public static event GameControllerEvents stopGameEvent;
	public Canvas canvas;

	public TimerRescue m_TimerRescue;
	public RescueUI m_RescueUI;
	public GameObject endMessage;
	public GameObject textWin;
	public GameObject textLose;
	public GameObject objectStart;
	public GameObject helpObject;
	public GameObject messageControls;
	public GameObject buttonPlay;
	public static int maxVictimToWin=5;
	RectTransform canvasRect;
	private Vector3 positionHelp;

	void OnEnable(){
		TimerRescue.timeEnd += LoseGame;
		RescueUI.allVictimsRescued += WinGame;
		GamePlaycontroller.helpVictim += ShowHelpMessage;
	}
	void OnDisable(){
		TimerRescue.timeEnd -= LoseGame;
		RescueUI.allVictimsRescued -= WinGame;
		GamePlaycontroller.helpVictim -= ShowHelpMessage;
	}
	void Start(){
		canvasRect =canvas.GetComponent<RectTransform>();
		OnStart ();
	}

	public void setButtonFocus(){
		EventSystem.current.SetSelectedGameObject (buttonPlay);
	}

	private void OnStart(){
		setButtonFocus ();
		HideHelpMessage ();
		objectStart.SetActive (true);
		textWin.SetActive (false);
		textLose.SetActive (false);
		endMessage.SetActive (true);
		messageControls.SetActive (false);
	}
	public void OnPlay(){
		print ("OnPlay");
		if (messageControls.activeInHierarchy) {
			RestartGame ();
		} else {
			endMessage.SetActive (true);
			textWin.SetActive (false);
			objectStart.SetActive (false);
			textLose.SetActive (false);
			messageControls.SetActive (true);
			setButtonFocus ();
		}
			

	}
	void Update(){
		if (helpObject.activeInHierarchy) {
			helpObject.transform.position =RectTransformUtility.WorldToScreenPoint (Camera.main,positionHelp);
		}
	}

	public void ShowHelpMessage(int indexambient,Vector3 position){
		
		if (Random.Range (0, 4) == 2) {
		position.y = 0;
		helpObject.SetActive (true);
		positionHelp = position;
	
		Invoke("HideHelpMessage",1);
		}
	}
	public void HideHelpMessage(){
		helpObject.SetActive (true);
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
		messageControls.SetActive (false);
		StopGame ();
		setButtonFocus ();
	}
	public void LoseGame(){
		
		endMessage.SetActive (true);
		textWin.SetActive (false);
		objectStart.SetActive (false);
		textLose.SetActive (true);
		messageControls.SetActive (false);
		StopGame ();
		setButtonFocus ();

	}
}
