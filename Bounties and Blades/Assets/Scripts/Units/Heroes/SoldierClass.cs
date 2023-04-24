using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class SoldierClass : BaseHero
{
    public SoldierClass()
    {
        setName("Soldier");
        setDescription("The soldier is a strong ass mf.");
        setHP(10);
        setArmor(0);
        setStat(0, 10);
        setStat(1, 2);
        setStat(2, 9);
        setStat(3, 2);
        setStat(4, 7);
        setStat(5, 4);
    }
    public new double getDamage(){

        // Generate a random integer between 1 and 100
        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10; 
        if (randomNumber > chanceToHit){
            return 0;
        }
        return getStat(0); // the stat that is returned depends on what kind of hero it is
    }
}
