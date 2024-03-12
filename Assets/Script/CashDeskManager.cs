using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CashDeskManager : MonoBehaviour
{
    [SerializeField] KeyValuePair<Dictionary<Item, int>, string> _orderAsked;
    public Dictionary<Item, int> OrderAsked { get { return _orderAsked.Key; } }
    [SerializeField] Dictionary<Item, int> _orderGiven = new Dictionary<Item, int>();

    [SerializeField] TextMeshPro _itemToGiveList;
    [SerializeField] TextMeshPro _textGlobe;

    [SerializeField] GameObject[] _customer;

    public static CashDeskManager instance;

    int _earning;
    int _penalization;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(NewCustomerArrive(5f));
    }

    public void GetOrder()
    {
        _orderAsked = Order.GenerateOrder();
        _textGlobe.text = _orderAsked.Value;
        _orderGiven.Clear();
    }

    public void PlaceItem(Item i)
    {
        if (_orderGiven.ContainsKey(i))
        {
            _orderGiven[i]++;
            _itemToGiveList.text += System.Environment.NewLine + i.Name;
            return;
        }

        _orderGiven.Add(i, 1);

        _itemToGiveList.text += System.Environment.NewLine + i.Name;
    }

    public void DeliverOrder()
    {
        if (_orderAsked.Key.Count < 1) { StartCoroutine(NewCustomerArrive()); return; }

        var succesFailure = _orderGiven.HowCorrect(_orderAsked.Key).ToList();

        int c = 0;

        foreach (var i in _orderGiven)
        {
            Debug.Log(succesFailure[c]);

            _earning += succesFailure[c] ? Prices.instance.GetPrice(i.Key) * i.Value : 0;
            _penalization += !succesFailure[c] ? Prices.instance.GetPrice(i.Key) * i.Value : 0;
            c++;
        }

        MoneyManager.instance.Earn(_earning);
        MoneyManager.instance.Spend(_penalization);

        _itemToGiveList.text = " ";

        _orderAsked.Key.Clear();

        StartCoroutine(NewCustomerArrive());
    }
    IEnumerator NewCustomerArrive()
    {
        foreach (var item in _customer)
        {
            item.SetActive(false);
        }

        yield return new WaitForSeconds(1f);

        foreach (var item in _customer)
        {
            item.SetActive(true);
        }

        GetOrder();
    }

    IEnumerator NewCustomerArrive(float f)
    {
        foreach (var item in _customer)
        {
            item.SetActive(false);
        }

        yield return new WaitForSeconds(f);

        foreach (var item in _customer)
        {
            item.SetActive(true);
        }

        GetOrder();
    }
}
