using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLogic : MonoBehaviour {
    public CardManager cardManager;

    public MapGeneraton mapGen;

    public CardSlot Slot;

    [Tooltip("# of units ontop of map.Height to Show winning screen (map.Height just is the height to the last obstacle)")]
    public float OverPosition = 4f;

    private void Start()
    {
        cardManager = cardManager == null ? GameObject.Find("UICards").GetComponent<CardManager>() : cardManager;

        // we need the height for the map, lets assume both maps have the same height and we just use the right one.
        mapGen = mapGen == null ? GameObject.Find("MapRight").GetComponent<MapGeneraton>() : mapGen;
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/GameOver");
        }
    }

    // Update is called once per frame
    void Update () {
        // Check, if player already at or after goal position
        if ((mapGen.Height + OverPosition) + mapGen.transform.position.y < 0)
        {
             UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/Win");
        }
	}
}
