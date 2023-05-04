using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class LevelTwoArmor : Armor
{
    public LevelTwoArmor(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType, Sprite sprite) : base(itemName, itemDescription, maxStackSize, modifiers, itemType, sprite)
    {
        itemName = "Level 2 Armor";
        itemDescription = "Lookig for some better bling? This might as well be Versace";
        maxStackSize = 1;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Armor;
        modifiers.Add(2, new StatModifier(0.15f, StatModType.PercentMult, this));
    }
}
