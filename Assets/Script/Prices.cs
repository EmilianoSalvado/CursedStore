using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Prices : MonoBehaviour
{
    [SerializeField] List<Item> _itemsAvailable = new List<Item>();
    public List<Item> ItemsAvailable { get { return _itemsAvailable; } }
    Dictionary<Item, int> _prices = new Dictionary<Item, int>();
    public Dictionary<Item, int> PricesList { get { return _prices; } }

    public static Prices instance;

    private void Awake()
    {
        instance = this;

        foreach (var item in _itemsAvailable)
        {
            var value = Random.Range(20,41);
            Debug.Log(value);
            _prices.Add(item, value);
        }
    }

    public int GetPrice(Item i)
    {
        foreach (var item in _prices)
        {
            if (i.Equals(item.Key))
                return item.Value;
        }

        return default;
    }
}