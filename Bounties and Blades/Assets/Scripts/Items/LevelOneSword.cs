using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class LevelOneSword : Weapon
{
    public LevelOneSword(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType,Sprite sprite) : base(itemName, itemDescription, maxStackSize, modifiers, itemType, sprite)
    {
        itemName = "Level 1 Sword";
        itemDescription = "This sword has been through the wringer, but we'll just say has been tried and tested, and don't ask why it keeps getting passed around";
        maxStackSize = 1;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Weapon;
        modifiers.Add(0, new StatModifier(0.075f, StatModType.PercentMult, this));
    }
}
