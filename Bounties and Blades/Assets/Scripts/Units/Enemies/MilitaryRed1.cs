using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryRed1 : BaseHero
{
    public MilitaryRed1()
    {
        setName("Private First Class");
        setDescription("Rank 1 in the Red Military.");
        setArmor(0);
        setStat(0, 6);
        setStat(1, 4);
        setStat(2, 6);
        setStat(3, 6);
        setStat(4, 6);
        setStat(5, 2);
        var hp = 10 + (int)getStat(4);
        setHP(hp);
        setMaxHP(hp);
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
