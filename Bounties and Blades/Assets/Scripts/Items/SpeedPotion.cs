using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class SpeedPotion : Consumable
{
    public SpeedPotion(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType, Sprite sprite) : base(itemName, itemDescription, maxStackSize, modifiers, itemType, sprite)
    {
        itemName = "Speed Potion";
        itemDescription = "Not a track star? Fear not! This potion will give you Usain Bolt levels of speed with none of the hard work!";
        maxStackSize = 5;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Consumable;
        modifiers.Add(1, new StatModifier(0.15f, StatModType.PercentAdd, this));
    }
}
