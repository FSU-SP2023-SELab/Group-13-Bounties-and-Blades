using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murderer : BaseHero
{
    public Murderer()
    {
        setName("Murderer");
        setDescription("Murderer... nuff said.");
        setHP(10);
        setArmor(0);
        setStat(0, 7);
        setStat(1, 7);
        setStat(2, 6);
        setStat(3, 5);
        setStat(4, 3);
        setStat(5, 5);
    }
    public override double getDamage()
    {

        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10;
        if (randomNumber > chanceToHit)
        {
            return 0;
        }
        return getStat(0);
    }
}
