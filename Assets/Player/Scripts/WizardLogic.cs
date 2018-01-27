using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLogic : MonoBehaviour {
    public CardManager cardManager;

    public CardSlot Slot;

    private void Start()
    {
        cardManager = cardManager == null ? GameObject.Find("UICards").GetComponent<CardManager>() : cardManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MapData mapData = collision.GetComponent<MapData>();
        bool alive = false;
        cardManager.UpdateCards();
        if (mapData != null)
        {
            foreach (Card card in Slot.GetCardsFromTransform())
            {
                if (mapData.Name == card.Name)
                {
                    alive = true;
                }
            }
        }
        if (!alive)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            Debug.Log("DEAD!");
        }
    }

    // Update is called once per frame
    void Update () {
		// TODO: check, if player already at or after goal position
	}
}
