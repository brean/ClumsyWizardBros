using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour {

	public int sceneNumber=0;

	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.0f; //Minimum time of that scene

	private void Start(){
        //Grab the only CanvasGroup in the scene - would lead to trouble if we would have more
        fadeGroup = MenuScene.FindCanvasGroup(GameObject.Find("Canvas").transform);
        if (fadeGroup == null)
        {
            Debug.LogWarning("can not find CanvasGroup (for fading in scene " + gameObject.scene.name + ")!");
            return;
        }
        fadeGroup.gameObject.SetActive(true);

		//Start with white screen
		fadeGroup.alpha = 1;

		//Preload the game
		//Since I have no external data because all the data is stored on the device itself I do not need to do something here

		//Get a timestamp of the completion time
		//if the loadtime ist superfast, give it a small buffer time so the user can see the logo
		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}

	private void Update(){
        if (fadeGroup == null) {
            return;
        }

        //Fade-In
        if (Time.time < minimumLogoTime) {
			fadeGroup.alpha = 1 - Time.time;
		}

		//Fade-Out
		if (Time.time > minimumLogoTime && loadTime != 0) {
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1) {
				SceneManager.LoadScene (sceneNumber);
			}
		}
	}

}
