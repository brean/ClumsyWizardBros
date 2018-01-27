using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * assignes cards to their slots (create initial game state)
 * slots are used to check if game has been finished.
 */
public class CardManager : MonoBehaviour {
    // list of all available cards.
    [Tooltip("Cards")]
    public List<GameObject> Cards = new List<GameObject>();

    [Tooltip("# of cards each player get")]
    public int CardsPerPlayer = 2;

    [Tooltip("UI-Container that we can add the ui-elements of the cards to (one for each player)")]
    public List<CardSlot> CardSlots;

    private void Start()
    {
        DrawCards();
    }

    // move cards around (OWNLY WORKS FOR 2 PLAYERS!)
    public void UpdateCards()
    {
        CardSlot slotOne = CardSlots[0];
        Card selectedOne = slotOne.GetSelectedCard();
        CardSlot slotTwo = CardSlots[1];
        Card selectedTwo = slotTwo.GetSelectedCard();
        if (selectedOne == null || selectedTwo == null)
        {
            // TODO: Animation
            return;
        }
        // TODO: Animation


        selectedOne.transform.SetParent(slotTwo.transform);
        selectedTwo.transform.SetParent(slotOne.transform);
        Toggle toggleOne = selectedOne.gameObject.GetComponent<Toggle>();
        Toggle toggleTwo = selectedTwo.gameObject.GetComponent<Toggle>();


        ToggleGroup groupOne = slotOne.GetComponent<ToggleGroup>();
        ToggleGroup groupTwo = slotTwo.GetComponent<ToggleGroup>();

        toggleOne.isOn = false;
        groupTwo.UnregisterToggle(toggleTwo);
        toggleOne.group = slotTwo.GetComponent<ToggleGroup>();

        
        toggleTwo.isOn = false;
        groupOne.UnregisterToggle(toggleOne);
        toggleTwo.group = groupOne;

    }

    public void DrawCards()
    {
        List<GameObject> Cards = new List<GameObject>(this.Cards);
        foreach (CardSlot slot in CardSlots)
        {
            slot.DestroyAllCards();
        }
        foreach (CardSlot slot in CardSlots)
        {
            for (int i = 0; i < CardsPerPlayer; i++)
            {
                int cardNr = UnityEngine.Random.Range(0, Cards.Count);
                slot.AddCard(Cards[cardNr]);
                Cards.RemoveAt(cardNr);
            }
        }
    }
}
