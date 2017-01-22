using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource footSteps;
	public AudioSource toolChange;
	public AudioSource musicBackground;
	public AudioSource musicBackground2;

	public AudioSource helpMe;
	public AudioSource help;
	public AudioSource Iamhere;
	public AudioSource rescueMe;
	public AudioSource Thanks;

	public AudioSource collapse;
	public AudioSource electricity;
	public AudioSource fire;
	public AudioSource siren;
	public AudioSource heart;
	public AudioSource wallcolapsing;

	public AudioSource abilityAxe;
	public AudioSource abilityExtinguicher;
	public AudioSource abilityLinterna;


	void OnEnable(){
		PlayerController.playerMove +=  PlayfootSteps;
		PlayerController.playerStop +=  StopfootSteps;

		PlayerController.playerMove +=  StopHeart;
		PlayerController.playerStop +=  PlayHeart;

		AbilityManager.abilityActive += PlayChangetool;
		GameController.restartGameEvent += PlayMusicBackground;
		GameController.stopGameEvent += StopMusic;
		TimerRescue.timeHalf += PlayMusicBackground2;
		GamePlaycontroller.helpVictim += PlayHelp;
		GamePlaycontroller.ambientSound += PlayRandomAmbient;
		Ability.usingAbility += PlayAbilityUse;
	}
	void OnDisable(){
		PlayerController.playerMove -=  PlayfootSteps;
		PlayerController.playerStop -=  StopfootSteps;
		PlayerController.playerMove -=  StopHeart;
		PlayerController.playerStop -=  PlayHeart;

		AbilityManager.abilityActive -= PlayChangetool;
		GameController.restartGameEvent -= PlayMusicBackground;
		GameController.stopGameEvent -= StopMusic;
		TimerRescue.timeHalf -= PlayMusicBackground2;
		GamePlaycontroller.helpVictim -= PlayHelp;
		GamePlaycontroller.ambientSound -= PlayRandomAmbient;

		Ability.usingAbility -= PlayAbilityUse;
	}
	public void PlayAbilityUse(string abilityName){
		switch (abilityName) {
		case "axe":
			abilityAxe.Play();
			break;
		case "extinguisher":
			abilityExtinguicher.Play ();
			break;
		case "bandages":
			
			break;
		case "flashlight":
			abilityLinterna.Play ();
			break;
		default:


			break;
		}
	}

	public void PlayRandomAmbient(int indexambient,Vector3 position){
		print ("PlayRandomAmbient");
		switch (indexambient) {
		case 1:

			AudioSource.PlayClipAtPoint (collapse.clip,position);
			break;
		case 2:
			AudioSource.PlayClipAtPoint (electricity.clip,position);
			break;
		case 3:
			AudioSource.PlayClipAtPoint (fire.clip,position);
			break;
		case 4:
			AudioSource.PlayClipAtPoint (siren.clip,position);
			break;
	
		case 5:
			AudioSource.PlayClipAtPoint (wallcolapsing.clip,position);
			break;
		}
	}
	public void StopHeart(){
		if(heart.isPlaying)
		heart.Stop ();
	}
	public void PlayHeart(){
		print ("PlayHeart");
		if(!heart.isPlaying)
		heart.Play ();
	}

	public void PlayHelp(int indexhelp,Vector3 position){
		switch (indexhelp) {
		case 1:
			
			AudioSource.PlayClipAtPoint (helpMe.clip,position);
			break;
		case 2:
			AudioSource.PlayClipAtPoint (help.clip,position);
			break;
		case 3:
			AudioSource.PlayClipAtPoint (Iamhere.clip,position);
			break;
		case 4:
			AudioSource.PlayClipAtPoint (rescueMe.clip,position);
			break;
		case 5:
			AudioSource.PlayClipAtPoint (Thanks.clip,position);
			break;
		}
	}
	public void PlayThanks(){
		Thanks.Play ();
	}
	public void StopMusic(){
		StopfootSteps();
		StopMusicBackground2 ();
		StopMusicBackground ();
		helpMe.Stop ();
		help.Stop ();
		Iamhere.Stop ();
		rescueMe.Stop ();
	    Thanks.Stop ();
		collapse.Stop ();
		electricity.Stop ();
		fire.Stop ();
		siren.Stop ();
		heart.Stop ();
		wallcolapsing.Stop ();


	}
	public void PlayMusicBackground2(){

		if (!musicBackground2.isPlaying) {
			PlayMusicBackground ();
			musicBackground2.Play();
		}

	}
	public void StopMusicBackground2(){
		musicBackground2.Stop();
	}
	public void PlayMusicBackground(){
		musicBackground.Play();
	}
	public void StopMusicBackground(){
		musicBackground.Stop();
	}
	public void PlayChangetool(string toolName){
		toolChange.Play ();
	}
	public void PlayfootSteps(){
		if(!footSteps.isPlaying)
		footSteps.Play();
	}
	public void StopfootSteps(){
		if(footSteps.isPlaying)
		footSteps.Stop();
	}

}
