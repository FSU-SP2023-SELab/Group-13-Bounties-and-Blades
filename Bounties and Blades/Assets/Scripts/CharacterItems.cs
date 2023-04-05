using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterClass;

public class CharacterItems
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public int maxStackSize;

    public virtual void Use(CharacterClass characterClass)
    {

    }

    public class Consumable
    {

    }

    public class Weapon
    {

    }

    public class Armor
    {

    }
     
}
