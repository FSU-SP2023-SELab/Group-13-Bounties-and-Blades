using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class LevelThreeArmor : Armor
{
    public LevelThreeArmor(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
    {
        itemName = "Level 3 Armor";
        itemDescription = "Some say that this could stop a howitzer";
        maxStackSize = 1;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Armor;
        modifiers.Add(2, new StatModifier(0.3f, StatModType.PercentMult, this));
    }
}
