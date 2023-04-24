using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BountiesAndBlades.BaseHero{
    public class BaseHero : BaseUnit
    {
        private static string className;
        private static string classDescription;

        private double HP;
        private double Armor;
        private double[] StatsList = new double[6]; //0 Strength, 1 Speed, 2 Defense, 3 Intelligence, 4 Constitution, 5 Luck


        private Dictionary<int, List<float>> modifiers = new Dictionary<int, List<float>>();
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

        public Dictionary<int, List<float>> getModifiers()
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
        public void addHP(int i) //negative i value when attacked
        {
            HP += i;
        }
        public void addArmor(int i) //negative i value when attacked
        {

            Armor += i;
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

        public void addModifier(int i, float s)
        {
            if (!modifiers.ContainsKey(i))
            {
                modifiers.Add(i, new List<float>());
            }
            modifiers[i].Add(s);
            StatsList[i] += ((s / 100) * StatsList[i]);
        }

        public virtual double getDamage()
        {

            // Generate a random integer between 1 and 100
            double randomNumber = Random.Range(1, 101);
            double chanceToHit = getStat(5) * 10;
            if (randomNumber > chanceToHit)
            {
                return 0;
            }
            return getStat(0); // the stat that is returned depends on what kind of hero it is
        }
    }
}

