using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour {
	private CardManager cardManager;

	public bool buttonUp = true;
	public bool isPlayerOne;

	public float speed = 2; // speed in meters per second

	void Start() {
		this.cardManager = GameObject.Find ("UICards").GetComponent<CardManager>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 moveDir = Vector3.zero;
        string p = isPlayerOne ? "P1" : "P2";
        moveDir.x = Input.GetAxis ("Horizontal" + p);
        moveDir *= speed * Time.deltaTime;

        if (transform.localPosition.x + moveDir.x > 2f ||
            transform.localPosition.x + moveDir.x < -2f)
        {
            return;
        }

        // move this object at frame rate independent speed:
        transform.position += moveDir;

        bool isSquareDown = Input.GetButton("Square" + p);
		bool isTriangleDown = Input.GetButton("Triangle" + p);
		bool isCircleDown = Input.GetButton("Circle" + p);

        List<Card> cards = this.cardManager.CardSlots[this.isPlayerOne ? 0 : 1].GetCardsFromTransform();
        Card middleCard = cards[1];
        Card leftCard = cards[0];
        Card rightCard = cards[2];

        if (isSquareDown && buttonUp){
			buttonUp = false;
            leftCard.GetComponent<Toggle>().isOn = true;
		}
		else if(isTriangleDown && buttonUp){
			buttonUp = false;
            middleCard.GetComponent<Toggle>().isOn = true;
		}
		else if(isCircleDown && buttonUp){
			buttonUp = false;
            rightCard.GetComponent<Toggle>().isOn = true;
		}
		else if(!isSquareDown && !isTriangleDown && !isCircleDown && !buttonUp){
			buttonUp = true;
		}

	}
}

