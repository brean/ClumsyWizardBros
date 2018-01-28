using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour {

	private CanvasGroup fadeGroup;
	private float fadeInSpeed = 0.33f;

    public static CanvasGroup FindCanvasGroup(Transform parent)
    {
        CanvasGroup grp = parent.GetComponent<CanvasGroup>();
        if (grp != null)
        {
            return grp;
        }
        foreach (Transform child in parent)
        {
            grp = FindCanvasGroup(child);
            if (grp != null)
            {
                return grp;
            }
        }
        return null;
    }

	// Use this for initialization
	private void Start () {
        //Grab the only CanvasGroup in the scene - would lead to trouble if we would have more than one
        fadeGroup = FindCanvasGroup(GameObject.Find("Canvas").transform);
        if (fadeGroup == null)
        {
            Debug.LogWarning("can not find CanvasGroup (for fading in scene " + gameObject.scene.name + ")!");
            return;
        }
        fadeGroup.gameObject.SetActive(true);
        //Start with white screen
        fadeGroup.alpha = 1;
	}
    
	private void Update () {
        //Fade-In
        if (fadeGroup != null && fadeGroup.alpha >= 0)
        {
            float newAlpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
            fadeGroup.alpha = newAlpha < 0 ? 0 : newAlpha;
        }
	}
}
