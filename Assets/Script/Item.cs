using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string _name;
    public string Name { get { return _name; } }
    [SerializeField] protected int _price;
    [SerializeField] ItemType _itemType;
    public ItemType GetItemType { get { return _itemType; } }
}

public enum ItemType { Potion, Edible }