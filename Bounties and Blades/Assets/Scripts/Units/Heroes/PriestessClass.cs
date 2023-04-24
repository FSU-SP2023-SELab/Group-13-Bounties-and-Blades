using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class PriestessClass : BaseHero
{
    public PriestessClass()
    {
        setName("Priestess");
        setDescription("The Priestess is a powerful, mystical woman who serves as a conduit between mortals and the divine.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 5);
        setStat(2, 5);
        setStat(3, 7);
        setStat(4, 8);
        setStat(5, 7);
    }
    public override double getDamage()
    {

        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10;
        if (randomNumber > chanceToHit)
        {
            return 0;
        }
        return getStat(3);
    }
}
