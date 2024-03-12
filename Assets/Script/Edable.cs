using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edable : Item
{
    [SerializeField] EdableType _edableType;
    public EdableType GetEdableType { get { return _edableType; } }
}

public enum EdableType { Magic, Light, Rotten, Frozen }