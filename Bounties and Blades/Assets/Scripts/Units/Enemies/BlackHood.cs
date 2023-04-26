using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHood : BaseHero
{
    public BlackHood()
    {
        setName("Black Hood");
        setDescription("Hooded death.");
        setHP(10);
        setArmor(0);
        setStat(0, 7);
        setStat(1, 4);
        setStat(2, 6);
        setStat(3, 4);
        setStat(4, 4);
        setStat(5, 4);
    }
    public new double getDamage()
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
