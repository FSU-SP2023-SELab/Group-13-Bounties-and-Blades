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

        private int HP;
        private int Armor;
        private int[] StatsList = new int[6]; //0 Strength, 1 Speed, 2 Defense, 3 Intelligence, 4 Constitution, 5 Luck

        private CharacterStats modifiers = new CharacterStats();
        public string getName()
        {
            return className;
        }
        public string getDescription()
        {
            return classDescription;
        }
        public int getHP()
        {
            return HP;
        }
        public int getArmor()
        {
            return Armor;
        }
        public int getStat(int i)
        {
            return StatsList[i];
        }
        public int[] getAllStats()
        {
            return StatsList;
        }

        public string[,] getModifiers()
        {
            string[,] r = new string[2, modifiers.StatModifiers.Count];

            for (int i = 0; i < modifiers.StatModifiers.Count; i++)
            {
                r[1, i] = modifiers.StatModifiers[i].Value.ToString();
                r[0, i] = modifiers.StatModifiers[i].Type.ToString();
            }

            return r;
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

        public void addModifier(StatModifier s)
        {
            modifiers.AddModifier(s);
        }

    }
}