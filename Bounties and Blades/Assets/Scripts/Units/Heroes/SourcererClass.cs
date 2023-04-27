using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class SourcererClass : BaseHero
{
    public SourcererClass()
    {
        setName("Sourcerer");
        setDescription("A sorcerer of dark arts, wielding forbidden spells, with a staff crackling with arcane energy, and eyes ablaze with malevolent power.");
        setArmor(0);
        setStat(0, 4);
        setStat(1, 3);
        setStat(2, 3);
        setStat(3, 10);
        setStat(4, 5);
        setStat(5, 7);
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
        return getStat(3); // the stat that is returned depends on what kind of hero it is
    }
}
