using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryGreen2 : BaseHero
{
    public MilitaryGreen2()
    {
        setName("Specialist");
        setDescription("Rank 2 in the Green Military.");
        setArmor(0);
        setStat(0, 7);
        setStat(1, 5);
        setStat(2, 7);
        setStat(3, 7);
        setStat(4, 7);
        setStat(5, 7);
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
