using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;


	// Use this for initialization
	private void Start () {
		//Grab the only CanvasGroup in the scene - would lead to trouble if we would have more
		fadeGroup = FindObjectOfType<CanvasGroup>();

		//Start with white screen
		fadeGroup.alpha = 1;

	}

	// Update is called once per frame
	private void Update () {
		//Fade-In
		fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
	}
	
}
