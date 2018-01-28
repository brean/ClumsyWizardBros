using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

    /*
     * TODO:
    private CanvasGroup FindCanvasGroup(Transform parent)
    {
        CanvasGroup grp = parent.GetComponent<CanvasGroup>();
        if (grp != null)
        {
            return grp;
        }
        foreach (Transform child in parent)
        {
            grp = FindCanvasGroup(child);
            if (child != null)
            {
                return grp;
            }
        }
        return grp;
    }
    */

	// Use this for initialization
	private void Start () {
        //Grab the only CanvasGroup in the scene - would lead to trouble if we would have more
        //fadeGroup = FindCanvasGroup(transform);
        fadeGroup = FindObjectOfType<CanvasGroup>();
        if (fadeGroup == null)
        {
            Debug.LogWarning("can not find CanvasGroup (for fading)!");
        }
        else
        {
            //Start with white screen
            fadeGroup.alpha = 1;
        }

	}

	// Update is called once per frame
	private void Update () {
		//Fade-In
        if (fadeGroup != null)
		    fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
	}
	
}
