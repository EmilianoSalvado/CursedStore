using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Order
{
    public static KeyValuePair<Dictionary<Item, int>, string> GenerateOrder()
    {
        string sentence = "me Say helLo, MisTRess WitCH. ";

        List<Slot> slots = StockManager.instance.Slots.Where(x => x.Contained  != null).RandomizeCollection().ToList();

        Dictionary<Item, int> itemNq = new Dictionary<Item, int>();

        foreach (var slot in slots)
        {
            if (slot.Contained != null)
            {
                if (UnityEngine.Random.Range(0, 3) > 0)
                {
                    itemNq.Add(slot.Contained, UnityEngine.Random.Range(1, slot.Quantity));
                    sentence += $"Me wAnt {itemNq[slot.Contained]} {slot.Contained.Specify()}.";
                }
            }

            if (UnityEngine.Random.Range(0, 3) > 0)
            {
                sentence += " ";
                continue;
            }

            break;
        }

        return new KeyValuePair<Dictionary<Item, int>, string>(itemNq, sentence);
    }
}