using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LocalizedText : MonoBehaviour {

	public string key;

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();
		text.text = LocalizationManager.instance.GetLocalizedValue (key);
	}
}
