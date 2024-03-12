using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StockManager : MonoBehaviour
{
    [SerializeField] List<Slot> _slots = new List<Slot>();
    public List<Slot> Slots { get { return _slots; } }

    public static StockManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(Item item)
    {        
        _slots.First(x => x.Quantity < x.MaxQuantity && (x.Contained.Specify() == item.Specify() || x.Contained == null)).AddItem(item);
    }

    public void Remove(Item item)
    {
        foreach (var slot in _slots)
        {
            if (slot.Contained == item)
            {
                slot.RemoveItem();
                break;
            }
        }
    }
}