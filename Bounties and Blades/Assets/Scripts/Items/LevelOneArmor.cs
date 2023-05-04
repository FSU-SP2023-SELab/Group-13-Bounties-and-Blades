using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class LevelOneArmor : Armor
{
    public LevelOneArmor(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
    {
        itemName = "Level 1 Armor";
        itemDescription = "Hey, it's better than nothing";
        maxStackSize = 1;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Armor;
        modifiers.Add(2, new StatModifier(0.075f, StatModType.PercentMult, this));
    }
}
