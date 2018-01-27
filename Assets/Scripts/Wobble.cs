using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour {
    public float wobbleX = 1.0f;
    public float wobbleY = 1.0f;
	
	// Update is called once per frame
	void Update () {
        transform.position.Set(
            Mathf.Sin(Time.time * wobbleX),
            Mathf.Sin(Time.time * wobbleY), 
            0);
	}
}
