using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashDeskButton : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        CashDeskManager.instance.DeliverOrder();
    }
}