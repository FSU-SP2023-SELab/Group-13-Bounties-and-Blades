namespace BountiesAndBlades.CharacterClass
{
    using BountiesAndBlades.CharacterStats;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using UnityEngine;

    public class CharacterClass
    {
        private string className;
        private string classDescription;

        private double HP;
        private double Armor;
        private double[] StatsList = new double[6]; //0 Strength, 1 Speed, 2 Defense, 3 Intelligence, 4 Constitution, 5 Luck
        //use 6 for HP, 7 for Armor when modifying stats.

        private Dictionary<string, float> modifiers = new Dictionary<string, float>();
        public string getName()
        {
            return className;
        }
        public string getDescription()
        {
            return classDescription;
        }
        public double getHP()
        {
            return HP;
        }
        public double getArmor()
        {
            return Armor;
        }
        public double getStat(int i)
        {
            return StatsList[i];
        }
        public double[] getAllStats()
        {
            return StatsList;
        }

        public Dictionary<string, float> getModifiers()
        {
            return modifiers;
        }

        public void setName(string n)
        {
            className = n;
        }

        public void setDescription(string s)
        {
            classDescription = s;
        }
        public void setHP(int i)
        {
            HP = i;
        }
        public void setArmor(int i)
        {

            Armor = i;
        }

        public void setStat(int i, int v)
        {
            StatsList[i] = v;
        }

        public void addModifier(int i, StatModifier s)
        {

            modifiers.Add(i.ToString(), s.Value);
            StatsList[i] += ((s.Value / 100)*StatsList[i]);
        }

    }
}