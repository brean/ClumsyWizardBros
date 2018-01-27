using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour {

    public List<Card> GetCardsFromTransform()
    {
        List<Card> Cards = new List<Card>();
        foreach (Transform slotItem in transform)
        {
            Card card = slotItem.GetComponent<Card>();
            if (card != null)
            {
                Cards.Add(card);
            }
        }
        return Cards;
    }

    public void DestroyAllCards()
    {
        foreach (Card card in GetCardsFromTransform())
        {
            Destroy(card.gameObject);
        }
    }



    public bool CardInSlot(Card selectedCard)
    {

        foreach (Card card in GetCardsFromTransform())
        {
            if (card == selectedCard)
            {
                return true;
            }
        }
        return false;
    }

    public void AddCard(GameObject cardPrefab)
    {
        GameObject go = Instantiate(cardPrefab, transform);
        go.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();
    }

    public string GetSelectedCardName()
    {
        Card selectedCard = GetSelectedCard();
        return selectedCard == null ? null : selectedCard.Name;
    }

    public Card GetSelectedCard()
    {
        foreach (Transform slotItem in transform)
        {
            if (slotItem.GetComponent<Toggle>().isOn)
            {
                return slotItem.gameObject.GetComponent<Card>();
            }
        }
        return null;
    }
}
