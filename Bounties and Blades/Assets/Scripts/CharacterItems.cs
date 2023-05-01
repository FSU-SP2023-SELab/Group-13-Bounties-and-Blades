namespace BountiesAndBlades.CharacterItems
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using BountiesAndBlades.BaseHero;
    using System.Data;
    using BountiesAndBlades.CharacterStats;
    using Unity.IO.LowLevel.Unsafe;

    public enum ItemType
    {
        Consumable,
        Weapon,
        Armor,
    }

    public class CharacterItems:MonoBehaviour
    {
        public string itemName;
        public string itemDescription;
        public int maxStackSize;
        public Dictionary<int, StatModifier> modifiers; //items may carry multiple modifiers, represented as a percent +/-
        public ItemType itemType;
        public Tile OccupiedTile;

        public CharacterItems(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.maxStackSize = maxStackSize;
            this.modifiers = modifiers;
        }

        public CharacterItems (string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
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
            if (this.modifiers == null)
            {
                hero.inventory.Remove(this);
                return;
            }
            if (this.itemType != ItemType.Consumable) 
            {
                foreach (var modifier in modifiers)
                {
                    hero.CharacterStatList[modifier.Key].RemoveModifier(modifier.Value);
                }
                if (hero.EquippedArmor == this || hero.EquippedWeapon == this)
                {
                    if (this.itemType == ItemType.Weapon) { hero.EquippedWeapon = null; }
                    else { hero.EquippedArmor = null; }
                    return;
                }
            }
            hero.inventory.Remove(this);
        }

        protected virtual void Unequip(BaseHero hero, CharacterItems item)
        {
            // overwritten by Weapon and Armor classes, not used in consumable
        }

        protected virtual void Equip(BaseHero hero, CharacterItems item) { } //ditto for Unequip

    }

    public class Consumable : CharacterItems
    {

        public Consumable(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            if (this.modifiers != null)
            {
                foreach (var modifier in this.modifiers)
                {
                    hero.CharacterStatList[modifier.Key].AddModifier(modifier.Value);
                }
            }
            hero.inventory.Remove(this);

        }
    }

    public class Weapon : CharacterItems
    {
        //increases strength stat during battle, potentially buff or nerf other stat
        public Weapon(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            if (hero.EquippedWeapon is not null) // take off modifiers from currently equipped weapon
            {
                if (this == hero.EquippedWeapon && hero.inventory.Count < 5)
                {
                    Unequip(hero, this);
                    return;
                }
                else if (this == hero.EquippedWeapon) return; 
                Unequip(hero, hero.EquippedWeapon);
            }
            Equip(hero, this);

        }

        protected override void Unequip (BaseHero hero, CharacterItems item)
        {
            if (hero.EquippedWeapon.modifiers is not null)
            {
                foreach (KeyValuePair<int, StatModifier> k in hero.EquippedWeapon.modifiers)
                {
                    hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                }
            }
            hero.inventory.Add(item);
            hero.EquippedWeapon = null;
        }

        protected override void Equip(BaseHero hero, CharacterItems item)
        {
            if (item.modifiers is not null)
            {
                foreach (var modifier in item.modifiers)
                {
                    hero.CharacterStatList[modifier.Key].AddModifier(modifier.Value);
                }
            }
            hero.EquippedWeapon = item;
            hero.inventory.Remove(item);
        }
    }

    public class Armor : CharacterItems
    {
        //increases HP stat during battle, potentially buff or nerf other stat
        public Armor(string itemName, string itemDescription, int maxStackSize, Dictionary<int, StatModifier> modifiers, ItemType itemType) : base(itemName, itemDescription, maxStackSize, modifiers, itemType)
        {
        }

        public override void Use(BaseHero hero)
        {
            if (hero.EquippedArmor is not null) // take off modifiers from currently equipped Armor
            {
                if (this == hero.EquippedArmor && hero.inventory.Count < 5)
                {
                    Unequip(hero, this);
                    return;
                }
                else if (this == hero.EquippedArmor) return;
                Unequip(hero, hero.EquippedArmor);
            }
            Equip(hero, this);

        }

        protected override void Unequip(BaseHero hero, CharacterItems item)
        {
            if (hero.EquippedArmor.modifiers is not null)
            {
                foreach (KeyValuePair<int, StatModifier> k in hero.EquippedArmor.modifiers)
                {
                    hero.CharacterStatList[k.Key].RemoveModifier(k.Value); // might be fucked
                }
            }
            hero.inventory.Add(item);
            hero.EquippedArmor = null;
        }

        protected override void Equip(BaseHero hero, CharacterItems item)
        {
            if (item.modifiers is not null)
            {
                foreach (var modifier in item.modifiers)
                {
                    hero.CharacterStatList[modifier.Key].AddModifier(modifier.Value);
                }
            }
            hero.EquippedArmor = item;
            hero.inventory.Remove(item);
        }
    }
}
