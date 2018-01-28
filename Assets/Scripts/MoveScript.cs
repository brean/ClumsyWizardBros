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
		if (isPlayerOne) {
			moveDir.x = Input.GetAxis ("HorizontalP1");
			// moveDir.z = Input.GetAxis ("VerticalP1");
		} else {
			moveDir.x = Input.GetAxis ("HorizontalP2");
			// moveDir.z = Input.GetAxis ("VerticalP2");
		}

		// move this object at frame rate independent speed:
		transform.position += moveDir * speed * Time.deltaTime;

		bool isSquareDown = (this.isPlayerOne && Input.GetButton("SquareP1")) || (!this.isPlayerOne && Input.GetButton("SquareP2"));
		bool isTriangleDown = (this.isPlayerOne && Input.GetButton ("TriangleP1")) || (!this.isPlayerOne && Input.GetButton ("TriangleP2"));
		bool isCircleDown = (this.isPlayerOne && Input.GetButton ("CircleP1")) || (!this.isPlayerOne && Input.GetButton ("CircleP2"));

		if(isSquareDown && buttonUp){
			buttonUp = false;

			if (this.isPlayerOne) {
				List<Card> cards = this.cardManager.CardSlots [0].GetCardsFromTransform ();
				Card firstCard = cards [0];
				foreach (Card card in cards) {
					if (card.transform.position.x < firstCard.transform.position.x) {
						firstCard = card;
					}
				}
				firstCard.GetComponent<Toggle> ().isOn = true;
			} else {
				List<Card> cards = this.cardManager.CardSlots[1].GetCardsFromTransform();
				Card firstCard = cards[0];
				foreach (Card card in cards)
				{
					if (card.transform.position.x < firstCard.transform.position.x)
					{
						firstCard = card;
					}
				}
				firstCard.GetComponent<Toggle>().isOn = true;
			}

		}
		else if(isTriangleDown && buttonUp){
			buttonUp = false;
			if(this.isPlayerOne) {
				Debug.Log("P1 pressed triangle");
			 	List<Card> cards = this.cardManager.CardSlots[0].GetCardsFromTransform();
				Card middleCard = cards[1];
				Card leftCard = cards [0];
				Card rightCard = cards [2];
				middleCard.GetComponent<Toggle>().isOn = true;
			} else {
				Debug.Log("P2 pressed triangle");
				List<Card> cards = this.cardManager.CardSlots[1].GetCardsFromTransform();
				Card middleCard = cards[1];
				Card leftCard = cards [0];
				Card rightCard = cards [2];
				middleCard.GetComponent<Toggle>().isOn = true;
			}
			
		}
		else if(isCircleDown && buttonUp){
			buttonUp = false;

			if (this.isPlayerOne) {
				List<Card> cards = this.cardManager.CardSlots [0].GetCardsFromTransform ();
				Card lastCard = cards [0];
				foreach (Card card in cards) {
					if (card.transform.position.x > lastCard.transform.position.x) {
						lastCard = card;
					}
				}
				lastCard.GetComponent<Toggle> ().isOn = true;
			} else {
				List<Card> cards = this.cardManager.CardSlots[1].GetCardsFromTransform();
				Card lastCard = cards[0];
				foreach (Card card in cards)
				{
					if (card.transform.position.x > lastCard.transform.position.x)
					{
						lastCard = card;
					}
				}
				lastCard.GetComponent<Toggle>().isOn = true;
			}
		}
		else if(!isSquareDown && !isTriangleDown && !isCircleDown && !buttonUp){
			buttonUp = true;
		}

	}
}

