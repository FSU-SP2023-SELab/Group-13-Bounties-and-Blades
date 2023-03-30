namespace BountiesAndBlades.CharacterStats
{
    /*
    Sources Sited:
    [1] Kryzarel (youtube), "Character Stats in Unity #1 - Base Implementation". Available: https://youtu.be/SH25f3cXBVc
    */

    using System;
    using System.Collections.Generic;
    using UnityEngine.UIElements;
    using System.Collections.ObjectModel;

    [Serializable]
    public class CharacterStats
    {
        public float BaseValue;

        public virtual float TotalValue
        {
            get
            {
                if (needsUpdate || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    needsUpdate = false;
                }
                return _value;
            }
        }

        protected bool needsUpdate = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;

        private readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers; // Allows players to see their stat modifiers

        public CharacterStats()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStats(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier modifier)
        {
            needsUpdate = true;
            statModifiers.Add(modifier);
            statModifiers.Sort();
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order) return -1;
            else if (a.Order > b.Order) return 1;
            return 0;
        }

        public virtual bool RemoveModifier(StatModifier modifier)
        {
            if (statModifiers.Remove(modifier))
            {
                needsUpdate = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = statModifiers.Count - 1; i >= 0; i++)
            {
                if (statModifiers[i].Source == source)
                {
                    needsUpdate = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier modifier = statModifiers[i];

                if (modifier.Type == StatModType.Flat)
                {
                    finalValue += statModifiers[i].Value; // For flat modifiers simply add them to the base stats
                }
                else if (modifier.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += modifier.Value;

                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (modifier.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + modifier.Value;
                }
            }

            return (float)Math.Round(finalValue, 4);
        }

    }
}