using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterClass;
using System.Data;

public class CharacterItems
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public int maxStackSize;
    public Dictionary<int, List<float>> modifiers; //items may carry multiple modifiers, represented as a percent +/-
    
    public virtual void Use(CharacterClass characterClass)
    {
        foreach(KeyValuePair<int, List<float>> k in modifiers)
        {
            foreach (float f in k.Value)
            {
                characterClass.addModifier(k.Key, f);
            }
        }
    }

    public class Consumable
    {

    }

    public class Weapon
    {
        //increases strength stat during battle, potentially buff or nerf other stat
    }

    public class Armor
    {
        //increases HP stat during battle, potentially buff or nerf other stat
    }

}
