using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class RogueClass : BaseHero
{
    public RogueClass()
    {
        setName("Rogue");
        setDescription("A cunning and elusive rogue with a sharp wit, quick reflexes, and a penchant for thievery and sabotage.");
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 6);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 7);
        setStat(5, 8);
    }
    public new double getDamage(){

        // Generate a random integer between 1 and 100
        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10; 
        if (randomNumber > chanceToHit){
            return 0;
        }
        return getStat(1); // the stat that is returned depends on what kind of hero it is
    }
}
