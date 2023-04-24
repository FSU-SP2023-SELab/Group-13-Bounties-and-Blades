using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpearman : BaseHero
{
    public ForestSpearman()
    {
        setName("Forest Spearman");
        setDescription("SPEARitual.");
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 7);
        setStat(2, 5);
        setStat(3, 5);
        setStat(4, 5);
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
        return getStat(1);
    }
}
