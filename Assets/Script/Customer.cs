using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    KeyValuePair<Dictionary<Item, int>, string> _itemQuantityNString;

    public void Start()
    {
        _itemQuantityNString = Order.GenerateOrder();
    }

    public bool CheckOrder(Dictionary<Item, int> given)
    {
        return given.Equals(_itemQuantityNString.Key);
    }
}
