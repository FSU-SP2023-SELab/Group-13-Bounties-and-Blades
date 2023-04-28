using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class Gapple : Consumable
{

    public Gapple(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base (itemName, itemDescription, maxStackSize, modifiers, itemType)
    {
        itemName = "Golden Apple";
        itemDescription = "Dire situation? All hope lost? Use this mystical apple to snatch victory from the jaws of defeat!";
        maxStackSize = 3;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Consumable;
        modifiers.Add(0, new StatModifier(0.3f, StatModType.PercentAdd, this));
        modifiers.Add(1, new StatModifier(.07f, StatModType.PercentMult, this));
        modifiers.Add(3, new StatModifier(2, StatModType.Flat,this));
    }
}
