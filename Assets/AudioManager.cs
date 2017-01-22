using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource footSteps;
	public AudioSource toolChange;
	public AudioSource musicBackground;
	public AudioSource musicBackground2;
	void OnEnable(){
		PlayerController.playerMove +=  PlayfootSteps;
		PlayerController.playerStop +=  StopfootSteps;
		AbilityManager.abilityActive += PlayChangetool;
		GameController.restartGameEvent += PlayMusicBackground;
		GameController.stopGameEvent += StopMusic;
		TimerRescue.timeHalf += PlayMusicBackground2;
	}
	void OnDisable(){
		PlayerController.playerMove -=  PlayfootSteps;
		PlayerController.playerStop -=  StopfootSteps;
		AbilityManager.abilityActive -= PlayChangetool;
		GameController.restartGameEvent += PlayMusicBackground;
		GameController.stopGameEvent += StopMusic;
		TimerRescue.timeHalf -= PlayMusicBackground2;

	}
	public void StopMusic(){
		StopfootSteps();
		StopMusicBackground2 ();
		StopMusicBackground ();
	}
	public void PlayMusicBackground2(){
		StopMusicBackground ();
		if(!musicBackground2.isPlaying)
		musicBackground2.Play();
	}
	public void StopMusicBackground2(){
		musicBackground2.Stop();
	}
	public void PlayMusicBackground(){
		musicBackground.Play();
		StopMusicBackground2 ();
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
