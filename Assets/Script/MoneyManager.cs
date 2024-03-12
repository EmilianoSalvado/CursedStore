using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] int _money;
    public int Money { get { return _money; } }

    [SerializeField] TextMeshPro _moneyTMP;

    public static MoneyManager instance;

    Action _updateMoney;

    private void Awake()
    {
        instance = this;

        _updateMoney = () => {
            _moneyTMP.text = "$ " + _money.ToString();
        };

        _updateMoney();
    }

    public void Spend(int q)
    {
        _money -= q;
        _updateMoney();
    }

    public void Earn(int q)
    {
        _money += q;
        _updateMoney();
    }

}
