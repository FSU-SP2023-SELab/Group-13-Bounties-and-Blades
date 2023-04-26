using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class ThiefClass : BaseHero
{
    public ThiefClass() 
    {
        setName("Thief");
        setDescription("A shadowy figure with keen eyes and swift movements, wielding enchanted tools to pilfer treasures from the unsuspecting.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 6);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 9);
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
