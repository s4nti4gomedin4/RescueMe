using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAbilities : MonoBehaviour {

	public Image axe;
	public Image extinguisher;
	public Image bandage;
	public Image flashlight;

	void OnEnable(){
		AbilityManager.abilityActive += ShowHability ;
	}
	void OnDisable(){
		AbilityManager.abilityActive-= ShowHability ;
	}
	public void ShowHability(string abilityName){
		switch (abilityName) {
		case "axe":
			axe.gameObject.SetActive (true);
			extinguisher.gameObject.SetActive (false);
			bandage.gameObject.SetActive (false);
			flashlight.gameObject.SetActive (false);
			break;
		case "extinguisher":
			axe.gameObject.SetActive (false);
			extinguisher.gameObject.SetActive (true);
			bandage.gameObject.SetActive (false);
			flashlight.gameObject.SetActive (false);
			break;
		case "bandages":
			axe.gameObject.SetActive (false);
			extinguisher.gameObject.SetActive (false);
			bandage.gameObject.SetActive (true);
			flashlight.gameObject.SetActive (false);
			break;
		case "flashlight":
			axe.gameObject.SetActive (false);
			extinguisher.gameObject.SetActive (false);
			bandage.gameObject.SetActive (false);
			flashlight.gameObject.SetActive (true);
			break;
		default:
			axe.gameObject.SetActive (false);
			extinguisher.gameObject.SetActive (false);
			bandage.gameObject.SetActive (false);
			flashlight.gameObject.SetActive (false);

			break;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
