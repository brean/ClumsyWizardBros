using System;
using UnityEngine;

[Serializable]
public class MapSegment {
    [Tooltip("Segment name")]
    public String Name;

    [Tooltip("Height of the segment (in Pixel)")]
    public int Height;

    [Tooltip("Prefab")]
    public GameObject Prefab;
}
