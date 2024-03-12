using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier : MonoBehaviour
{
    [SerializeField] List<SupplyButton> _supplyButtons = new List<SupplyButton>();

    private void Start()
    {
        int a = 0;

        foreach (var button in _supplyButtons)
        {
            button.Initialize(Prices.instance.ItemsAvailable[a]);
            a++;
        }
    }
}