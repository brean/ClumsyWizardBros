using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    public CardManager cardManager;

	// Use this for initialization
	void Start () {
        cardManager = cardManager == null ? GameObject.Find("UICards").GetComponent<CardManager>() : cardManager;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
