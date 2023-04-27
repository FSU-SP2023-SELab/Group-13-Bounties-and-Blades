namespace BountiesAndBlades.BaseHero {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using BountiesAndBlades.CharacterItems;
    using BountiesAndBlades.CharacterStats;
    // using BountiesAndBlades.InventorySystem;



    public abstract class BaseHero : BaseUnit
    {
        private static string className;
        private static string classDescription;

        private int HP;
        private int maxHP;
        private double Armor;
        private double[] StatsList = new double[6]; //0 Strength, 1 Speed, 2 Defense, 3 Intelligence, 4 Constitution, 5 Luck
        public List<CharacterItems> inventory = new List<CharacterItems>();
        public CharacterItems EquippedWeapon = null;
        public CharacterItems EquippedArmor = null;
        public Dictionary<int,CharacterStats> CharacterStatList = new Dictionary<int,CharacterStats>();


        private Dictionary<int, List<float>> modifiers = new Dictionary<int, List<float>>();
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

        public int getMaxHP(){
            return maxHP;
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

        public void setMaxHP(int i){
            maxHP = i;
        }
        public void setArmor(int i)
        {
            Armor = i;
        }

        public void setStat(int i, int v)
        {
            if (!CharacterStatList.ContainsKey(i))
            {
                CharacterStatList.Add(i, new CharacterStats(v));
            }
            else {
                CharacterStatList[i].BaseValue = v;
            }
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

        public abstract double getDamage();

        public bool TakeDamage(int dmg){
            if(dmg == 0){
                return false;
            }
            if(dmg - (int)StatsList[2]/2.5 <= 0){
                HP -= 1;
            }
            else{
                HP -= (int)(dmg - StatsList[2]/2.5); //armor mitigated the damage
            }
            if (HP <= 0){
                return true;
            }
            return false;
        }

        public void useItem(CharacterItems item) 
        {
            // need to call this from the child class,
            // call the use function on item, all the
            // subclasses have it overwritten to handle
            // their respective cases
            item.Use(this);
        }

        public void Dump(CharacterItems item)
        {
            item.Dump(this);
        }

    }
}