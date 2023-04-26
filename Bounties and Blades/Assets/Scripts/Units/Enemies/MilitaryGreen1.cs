using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryGreen1 :  BaseHero
{
    public MilitaryGreen1()
    {
        setName("Miltary Green 1");
        setDescription("Rank 1 in the Green Military.");
        setHP(10);
        setArmor(0);
        setStat(0, 6);
        setStat(1, 4);
        setStat(2, 6);
        setStat(3, 6);
        setStat(4, 6);
        setStat(5, 6);
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
