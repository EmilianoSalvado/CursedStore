using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour, IClickable
{
    [SerializeField] Item _original;
    [SerializeField] Item _contained;
    public Item Contained { get { return _contained; } }
    [SerializeField] int _quantity;
    public int Quantity { get { return _quantity; } }
    [SerializeField] int _maxQuantity;
    public int MaxQuantity { get { return _maxQuantity; } }

    [SerializeField] TextMeshPro _containedNameTMP;
    [SerializeField] TextMeshPro _quantityTMP;

    Action _updateStore;

    private void Awake()
    {
        _updateStore = () =>
        {
            if (_contained == null)
            {
                _containedNameTMP.text = "Empty Slot";
                _quantityTMP.text = $"x0";
                return;
            }

            _containedNameTMP.text = _contained.Name;
            _quantityTMP.text = $"x {_quantity}";
        };

        _updateStore();
    }

    public void AddItem(Item item)
    {
        if (_quantity >= _maxQuantity) return;

        if (_contained == null)
        {
            _original = item;
            _contained = Instantiate(item, transform);
            _contained.transform.localPosition = Vector3.zero;
        }
        _quantity++;
        UpdateStore();
    }

    public void RemoveItem()
    {
        if (_quantity < 1) return;
        _quantity--;

        if (_quantity <= 0)
        {
            Destroy(_contained.gameObject);
            _contained = null;
            _original = null;
        }
        UpdateStore();
    }

    void UpdateStore()
    {
        if (_contained == null)
        {
            _containedNameTMP.text = "Empty Slot";
            _quantityTMP.text = $"x0";
            return;
        }

        _containedNameTMP.text = _contained.Name;
        _quantityTMP.text = $"x {_quantity}";
    }

    public void OnClick()
    {
        if (_contained == null) return;

        CashDeskManager.instance.PlaceItem(_original);
        StockManager.instance.Remove(_contained);
    }
}