using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public static class Generators
{
    public static string Specify(this Item item)
    {
        string specificType;

        if (item is Potion)
        {
            specificType = "pOtiON";

            switch ((item as Potion).GetPotionType)
            {
                case PotionType.Poison:
                    specificType += "PoISon";
                    break;
                case PotionType.Health:
                    specificType += "heaLth";
                    break;
                case PotionType.Love:
                    specificType += "LovE";
                    break;
                case PotionType.Death:
                    specificType += "deATh";
                    break;
            }

            return specificType;
        }

        specificType = "";

        if (item is Edable)
        {
            switch ((item as Edable).GetEdableType)
            {
                case EdableType.Magic:
                    specificType += " maGic wOrm. ";
                    break;
                case EdableType.Light:
                    specificType += " lighT woRM. ";
                    break;
                case EdableType.Frozen:
                    specificType += " frOZen aPple. ";
                    break;
                case EdableType.Rotten:
                    specificType += " rottEN AppLe. ";
                    break;
            }
        }

        return specificType;
    }

    public static IEnumerable<T> RandomizeCollection<T>(this IEnumerable<T> col)
    {
        foreach (var item in col)
        {
            col = col.OrderBy((x) => Random.Range(0, col.Count()) > Random.Range(0, col.Count()));
        }

        return col;
    }

    public static IEnumerable<bool> HowCorrect(this Dictionary<Item, int> a, Dictionary<Item, int> b)
    {
        foreach (var item1 in a)
        {
            yield return b.Any(x => x.Key.Specify() == item1.Key.Specify() && x.Value >= item1.Value);
        }
    }
}