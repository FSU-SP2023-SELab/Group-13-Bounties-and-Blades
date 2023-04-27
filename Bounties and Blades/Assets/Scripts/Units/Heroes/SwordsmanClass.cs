using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class SwordsmanClass : BaseHero
{
    public SwordsmanClass() 
    {
        setName("Swordsman");
        setDescription("A master swordsman, wielding a gleaming blade with unmatched skill, swift and deadly in battle, feared and respected by all.");
        setArmor(0);
        setStat(0, 6);
        setStat(1, 4);
        setStat(2, 8);
        setStat(3, 7);
        setStat(4, 6);
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
        return getStat(0); // the stat that is returned depends on what kind of hero it is
    }
}
