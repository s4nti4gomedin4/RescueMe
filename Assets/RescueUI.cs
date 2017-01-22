using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueUI : MonoBehaviour {

	public delegate void RescueUIEvent ();
	public static event RescueUIEvent allVictimsRescued;

	private Text victimRescueText;
	public  int rescue;

	void OnEnable(){
		FollowZone.victimSave += RescueVictim;
	}
	void OnDisable(){
		FollowZone.victimSave -= RescueVictim;
	}
	void RescueVictim(){
		rescue++;
		victimRescueText.text = string.Format ("{0}/{1}",rescue,GameController.maxVictimToWin);
	}

	// Use this for initialization
	void Start () {
		rescue = 0;
		victimRescueText = GetComponent<Text> ();
		victimRescueText.text = string.Format ("{0}/{1}",rescue,GameController.maxVictimToWin);
	}
	void Update(){
		if (rescue == GameController.maxVictimToWin) {
			if (allVictimsRescued != null) {
				allVictimsRescued ();
			}
		}
	}

}
