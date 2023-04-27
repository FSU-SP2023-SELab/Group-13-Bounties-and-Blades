using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class RangerClass : BaseHero
{
    public RangerClass() 
    {
        setName("Ranger");
        setDescription("A skilled woodsman armed with a bow, tracking skills, and a bond with nature, guarding the wilderness from threats.");
        setArmor(0);
        setStat(0, 5);
        setStat(1, 6);
        setStat(2, 4);
        setStat(3, 8);
        setStat(4, 4);
        setStat(5, 5);
        var hp = 10 + (int)getStat(4);
        setHP(hp);
        setMaxHP(hp);
    }
    public override double getDamage(){

        // Generate a random integer between 1 and 100
        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10; 
        if (randomNumber > chanceToHit){
            return 0;
        }
        return getStat(1); // the stat that is returned depends on what kind of hero it is
    }
}
