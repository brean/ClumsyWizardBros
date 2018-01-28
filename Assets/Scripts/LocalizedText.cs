using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LocalizedText : MonoBehaviour {

	public string key;

    public Text FindText(Transform parent)
    {
        Text text = parent.GetComponent<Text>();
        if (text != null)
        {
            return text;
        }
        else
        {
            foreach (Transform child in parent)
            {
                text = FindText(child);
                if (text != null)
                {
                    return text;
                }
            }
        }
        return null;
    }

	// Use this for initialization
	void Start () {
		Text text = FindText(transform);
        if (text != null)
        {
            text.text = LocalizationManager.instance.GetLocalizedValue(key);
        } else
        {
            Debug.LogWarning("Can not translate " + key + " no text attached to GameObject" + gameObject.name + "!");
        }
	}
}
