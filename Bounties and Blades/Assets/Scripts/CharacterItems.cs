namespace BountiesAndBlades.CharacterItems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using BountiesAndBlades.BaseHero;
    using System.Data;
    using BountiesAndBlades.CharacterStats;

    public enum ItemType
    {
        Consumable,
        Weapon,
        Armor,
    }

    public class CharacterItems
    {
        public string itemName;
        public string itemDescription;
        public Sprite icon;
        public int maxStackSize;
        public Dictionary<int, StatModifier> modifiers; //items may carry multiple modifiers, represented as a percent +/-
        public ItemType itemType;

        public CharacterItems(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, StatModifier> modifiers)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.icon = icon;
            this.maxStackSize = maxStackSize;
            this.modifiers = modifiers;
        }

        public CharacterItems (string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.icon = icon;
            this.maxStackSize = maxStackSize;
            this.modifiers = modifiers;
            this.itemType = itemType;
        }

        public virtual void Use(BaseHero hero)
        {
            // Is going to get overwritten
            /*
            foreach (KeyValuePair<int, List<float>> k in modifiers)
            {
                foreach (float f in k.Value)
                {
                    hero.addModifier(k.Key, f);
                }
            }*/
        }

        public virtual void Dump(BaseHero hero)
        {
            if (this.itemType != ItemType.Consumable) 
            {
                foreach (var modifier in modifiers)
                {
                    hero.CharacterStatList[modifier.Key].RemoveModifier(modifier.Value);
                }
                if (hero.EquippedArmor == this || hero.EquippedWeapon== this)
                {
                    if (this.itemType == ItemType.Weapon) { hero.EquippedWeapon = null; }
                    else { hero.EquippedArmor = null; }
                    return;
                }
            }
            hero.inventory.Remove(this);
        }

    }

    public class Consumable : CharacterItems
    {

        public Consumable(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            foreach (var modifier in this.modifiers) 
            {
                hero.CharacterStatList[modifier.Key].AddModifier(modifier.Value);
            }
            hero.inventory.Remove(this);

        }
    }

    public class Weapon : CharacterItems
    {
        //increases strength stat during battle, potentially buff or nerf other stat
        public Weapon(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            // need to add an if statement that checks whether the hero
            // already has a weapon equipped, and if they do it need to add
            // it to the hero's inventory before replacing it with the armor
            // they want to equip
            if (hero.EquippedWeapon == this)
            {
                if (hero.inventory.Count < 5)
                {
                    foreach (KeyValuePair<int, StatModifier> k in hero.EquippedWeapon.modifiers)
                    {
                        hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                    }
                    hero.inventory.Add(this);
                    hero.EquippedWeapon = null;
                }
                return;
            }
            if (hero.EquippedWeapon is not null)
            {
                foreach (KeyValuePair<int, StatModifier> k in hero.EquippedWeapon.modifiers)
                {
                    hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                }
                hero.inventory.Add(hero.EquippedWeapon);
                hero.EquippedWeapon = null;
            }
            hero.EquippedWeapon = this;
            hero.inventory.Remove(this);
            foreach (KeyValuePair<int, StatModifier> k in modifiers)
            {
                hero.CharacterStatList[k.Key].AddModifier(k.Value);
            }
        }
    }

    public class Armor : CharacterItems
    {
        //increases HP stat during battle, potentially buff or nerf other stat
        public Armor(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            // Need the same if statement as weapon, except it needs to check
            // for armor
            if (hero.EquippedArmor == this)
            {
                if (hero.inventory.Count < 5)
                {
                    foreach (KeyValuePair<int, StatModifier> k in hero.EquippedArmor.modifiers)
                    {
                        hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                    }
                    hero.inventory.Add(this);
                    hero.EquippedArmor = null;
                    
                }
                return;
            }
            if (hero.EquippedArmor is not null)
            {
                foreach (KeyValuePair<int, StatModifier> k in hero.EquippedArmor.modifiers)
                {
                    hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                }
                hero.inventory.Add(hero.EquippedArmor); 
                hero.EquippedArmor = null;
            }
            hero.EquippedArmor = this;
            hero.inventory.Remove(this);
            foreach (KeyValuePair<int, StatModifier> k in modifiers)
            {
                hero.CharacterStatList[k.Key].AddModifier((StatModifier)k.Value);
            }
        }
    }
}
