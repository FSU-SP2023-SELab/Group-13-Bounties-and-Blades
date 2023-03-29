/*
Sources Sited:
[1] Kryzarel (youtube), "Character Stats in Unity #1 - Base Implementation". Available: https://youtu.be/SH25f3cXBVc
*/

using System;
using System.Collections.Generic;

public class CharacterStats
{
    public float BaseValue;

    public float TotalValue { get {
            if (needsUpdate)
            {
                _value = CalculateFinalValue();
                needsUpdate = false;
            }
            return _value;
            } }

    private bool needsUpdate = true;
    private float _value;

    private readonly List<StatModifier> statModifiers;

    public CharacterStats(float baseValue)
    {
        BaseValue = baseValue;
        statModifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier modifier)
    {
        needsUpdate = true;
        statModifiers.Add(modifier);
        statModifiers.Sort();
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order) return -1;
        else if (a.Order > b.Order) return 1;
        return 0;
    }

    public void RemoveModifier(StatModifier modifier)
    {
        needsUpdate = true;
        statModifiers.Remove(modifier);
    }

    private float CalculateFinalValue()
    {
        float finalValue = BaseValue;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier modifier = statModifiers[i];

            if (modifier.Type == StatModType.Flat)
            {
                finalValue += statModifiers[i].Value; // For flat modifiers simply add them to the base stats
            }
            else if (modifier.Type == StatModType.Percent)
            {
                finalValue *= 1 + modifier.Value;
            }
        }

        return (float)Math.Round(finalValue, 4); 
    }

}
