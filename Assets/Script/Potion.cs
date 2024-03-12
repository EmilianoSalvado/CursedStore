using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    [SerializeField] protected PotionType _potionType;
    public PotionType GetPotionType { get { return _potionType; } }
}

public enum PotionType { Poison, Health, Love, Death }