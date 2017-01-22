using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerRescue : MonoBehaviour {

	public delegate void  TimerRescueEvent();
	public static event TimerRescueEvent timeEnd;
	public static event TimerRescueEvent timeHalf;

	public Image mImagetimer;
	public  int secondsToDead;
	public Sprite[] sprites;
	public float timeElapse;
	public  bool timerOn;
	// Use this for initialization
	void Start () {
		timeElapse = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timerOn) {
			timeElapse += Time.deltaTime;
			float percent = timeElapse/secondsToDead*100;
			if (percent < 11) {
				mImagetimer.sprite = sprites [0];
			}else if (percent <22) {
				mImagetimer.sprite = sprites [1];
			}else if (percent < 33) {
				mImagetimer.sprite = sprites [2];
			}else if (percent < 44) {
				mImagetimer.sprite = sprites [3];
			}else if (percent <55) {
				mImagetimer.sprite = sprites [4];
				if (timeHalf != null) {
					timeHalf ();
				}
			}else if (percent < 66) {
				mImagetimer.sprite = sprites [5];
			}else if (percent < 77) {
				mImagetimer.sprite = sprites [6];
			}else if (percent < 88) {
				mImagetimer.sprite = sprites [7];
			}else {
				mImagetimer.sprite = sprites [8];
				if (timeEnd != null) {
					timeEnd ();
				}
				timerOn = false;
			}
		}

		
	}
}
