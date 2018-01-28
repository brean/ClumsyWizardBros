using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour {
	private Vector3 yPosDelta;
	private string gameObjKey;
	private int minPos;

	// Use this for initialization
	void Start() {
		this.yPosDelta = new Vector3 (0, 2.35f, 0);
		this.minPos = -1000;
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObjKey == "") {
			return;
		}

		if (this.transform.position.y < this.minPos) {
			Camera.main.GetComponent<BGObjectGenerator> ().removeSprite (this.gameObjKey);
		}

		this.transform.position -= this.yPosDelta;
	}

	public void setGOKey(string key) {
		this.gameObjKey = key;
	}

	public void setSpeed(float speed) {
		this.yPosDelta = new Vector3 (0, speed, 0);
	}

	public void setMinPos(int pos) {
		this.minPos = pos;
	}
}
