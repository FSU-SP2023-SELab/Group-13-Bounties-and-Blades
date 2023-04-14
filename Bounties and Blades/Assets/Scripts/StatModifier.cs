namespace BountiesAndBlades.CharacterStats
{
    /*
    Sources Sited:
    [1] Kryzarel (youtube), "Character Stats in Unity #1 - Base Implementation". Available: https://youtu.be/SH25f3cXBVc
    */

    public enum StatModType
    {
        Flat = 100,
        PercentAdd = 200,
        PercentMult = 300,
    }
    public class StatModifier
    {
        public readonly float Value;
        public readonly StatModType Type;
        public readonly int Order;
        public readonly object Source; // Shows where certain modifiers are coming from

        public StatModifier(float value, StatModType type, int order, object source)
        {
            Value = value;
            Type = type;
            Order = order;
            Source = source;
        }

        public StatModifier(float value, StatModType type) : this(value, type, (int)type, null) { }

        public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

        public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }

       override
            public string ToString()
        { 
            return Type.ToString() + ", " + Value.ToString();
        }
    }
}