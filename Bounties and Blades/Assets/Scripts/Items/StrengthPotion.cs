using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterItems;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterStats;

public class StrengthPotion : Consumable
{
    public StrengthPotion(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType) 
    {
        itemName = "Strength Potion";
        itemDescription = "Skip the gym one too many times and it's starting to show? Drink this! (Bounites&Blades LLC is not liable for any subsequent failed drug tests)";
        maxStackSize = 5;
        modifiers = new Dictionary<int, StatModifier>();
        itemType = ItemType.Consumable;
        modifiers.Add(0, new StatModifier(0.15f, StatModType.PercentAdd, this));
    }
}
