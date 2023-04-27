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
        public Dictionary<int, List<float>> modifiers; //items may carry multiple modifiers, represented as a percent +/-
        public ItemType itemType;

        public CharacterItems(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, List<float>> modifiers)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.icon = icon;
            this.maxStackSize = maxStackSize;
            this.modifiers = modifiers;
        }

        public CharacterItems (string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, List<float>> modifiers, ItemType itemType)
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

    }

    public class Consumable : CharacterItems
    {

        public Consumable(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, List<float>> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {

        }
    }

    public class Weapon : CharacterItems
    {
        //increases strength stat during battle, potentially buff or nerf other stat
        public Weapon(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, List<float>> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
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
                    hero.inventory.Add(this);
                    hero.EquippedWeapon = null;
                }
                return;
            }
            if (hero.EquippedWeapon is not null)
            {
                hero.inventory.Add(hero.EquippedWeapon);
                hero.EquippedWeapon = null;
            }
            hero.EquippedWeapon = this;
            hero.inventory.Remove(this);
            foreach (KeyValuePair<int, List<float>> k in modifiers)
            {
                foreach (float f in k.Value)
                {
                    hero.addModifier(k.Key, f);
                }
            }
        }
    }

    public class Armor : CharacterItems
    {
        //increases HP stat during battle, potentially buff or nerf other stat
        public Armor(string itemName, string itemDescription, Sprite icon, int maxStackSize, Dictionary<int, List<float>> modifiers, ItemType itemType) : base(itemName, itemDescription, icon, maxStackSize, modifiers, itemType)
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
                    hero.inventory.Add(this);
                    hero.EquippedArmor = null;
                    
                }
                return;
            }
            if (hero.EquippedArmor is not null)
            {
                hero.inventory.Add(hero.EquippedArmor); 
                hero.EquippedArmor = null;
            }
            hero.EquippedArmor = this;
            hero.inventory.Remove(this);
            foreach (KeyValuePair<int, List<float>> k in modifiers)
            {
                foreach (float f in k.Value)
                {
                    hero.addModifier(k.Key, f);
                }
            }
        }
    }
}
