using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Taxes : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ApplyTaxes());
    }

    public int CalcucateTaxes()
    {
        float _edableTax = 1.5f;
        float _potionTax = 2.5f;

        var all = StockManager.instance.Slots.Select(x => x.Contained).ToList();

        return Mathf.RoundToInt(all.OfType<Edable>().Count() * _edableTax) + Mathf.RoundToInt(all.OfType<Potion>().Count() * _potionTax);
    }

    IEnumerator ApplyTaxes()
    {
        while (true)
        {
            MoneyManager.instance.Spend(CalcucateTaxes());
            yield return new WaitForSeconds(5f);
        }
    }
}