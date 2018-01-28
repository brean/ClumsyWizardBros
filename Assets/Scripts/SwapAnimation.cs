using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapAnimation : MonoBehaviour {
    public int fps = 2;
    private int pos = 0;
    private float lastTime;

    public List<Sprite> sprites;


	// Use this for initialization
	void Start () {
        lastTime = Time.time;
	}

    void switchImage()
    {
        pos++;
        GetComponent<SpriteRenderer>().sprite = sprites[pos % sprites.Count];
    }

    public void disableMe()
    {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastTime > 1.0/fps)
        {
            switchImage();
            lastTime = Time.time;
        }
	}
}
