using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class LevelThreeSword : Weapon
{
    public LevelThreeSword(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
    {
        itemName = "Level 3 Sword";
        itemDescription = "Ender Dragon? Night King? Greek Gods? The Covenant? This sword will make short work of 'em all!";
        maxStackSize = 1;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Weapon;
        modifiers.Add(0, new StatModifier(0.3f, StatModType.PercentMult, this));
    }
}
