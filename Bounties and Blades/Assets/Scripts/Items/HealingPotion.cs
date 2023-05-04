using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class HealingPotion : Consumable
{
    public HealingPotion(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType, Sprite sprite) : base(itemName, itemDescription, maxStackSize, modifiers, itemType, sprite) 
    {
        itemName = "Defense Potion";
        itemDescription = "Taking some heavy hits? Drink this potion to bolster your defenses!";
        maxStackSize = 5;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Consumable;
        modifiers.Add(2, new StatModifier(0.15f, StatModType.PercentAdd, this));
    }

}
