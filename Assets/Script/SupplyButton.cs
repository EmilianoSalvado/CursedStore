using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class SupplyButton : MonoBehaviour, IClickable
{
    [SerializeField] Item _correspondedItem;
    [SerializeField] TextMeshPro _textMeshPro;
    [SerializeField] int _supplyPrice;

    public void Initialize(Item i)
    {
        _correspondedItem = i;
        _supplyPrice = Mathf.RoundToInt(Prices.instance.GetPrice(_correspondedItem) * .3f);
        _textMeshPro.text = _correspondedItem.Name + ": $" + Prices.instance.GetPrice(_correspondedItem);
    }

    public void OnClick()
    {
        if (!StockManager.instance.Slots.Any(x => x.Quantity < x.MaxQuantity && (x.Contained.Specify() == _correspondedItem.Specify() || x.Contained == null))) return;

        StockManager.instance.AddItem(_correspondedItem);
        MoneyManager.instance.Spend(_supplyPrice);
    }
}
