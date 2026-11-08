using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneraton : MonoBehaviour {
    float speed = 1f;

    [Tooltip("segments we created")]
    private List<KeyValuePair<int, GameObject>> map = new List<KeyValuePair<int, GameObject>>();

    // height of the map
    public float Height = 0;

    public void ResetMap()
    {
        foreach (KeyValuePair<int, GameObject> mapElem in map)
        {
            Destroy(mapElem.Value);
        }
        Height = 0;
    }

    public void AddMapElementAt(float EmptyBeforeMapStart, int i, GameObject segment)
    {
        GameObject go = Instantiate(segment, transform);
        float localHeight = 6.0f; //fixed distance between elements @ 6 unity units, alternative: go.GetComponent<BoxCollider2D>().size.y;
        go.transform.position = new Vector3(transform.position.x, EmptyBeforeMapStart + Height + localHeight / 2, 0);
        go.SetActive(true);
        Height += localHeight;
    }

    public void Update()
    {
        transform.Translate(Vector3.down * Time.fixedDeltaTime * speed);
    }
}
