using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    [Tooltip("all possible segments we create the map from")]
    public List<GameObject> segments = new List<GameObject>();

    public int SegmentsForMap = 10;
    public float EmptyBeforeMapStart = 3f;

    public List<MapGeneraton> mapGens = new List<MapGeneraton>();

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            MapGeneraton mg = child.gameObject.GetComponent<MapGeneraton>();
            if (mg != null)
            {
                mapGens.Add(mg);
            }
        }
        CreateMap();
    }

    public void CreateMap()
    {
        for (int i = 0; i < SegmentsForMap; i++)
        {
            List<GameObject> segments = new List<GameObject>(this.segments);
            foreach (MapGeneraton mapGenerator in mapGens)
            {
                int segmentNr = Random.Range(0, segments.Count);
                GameObject segment = segments[segmentNr];
                segments.RemoveAt(segmentNr);
                mapGenerator.AddMapElementAt(EmptyBeforeMapStart, i, segment);
            }
        }
    }
}
