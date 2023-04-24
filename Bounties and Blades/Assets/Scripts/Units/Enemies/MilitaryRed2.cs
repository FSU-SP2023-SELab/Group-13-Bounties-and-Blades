using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryRed2 : BaseHero
{
    public MilitaryRed2()
    {
        setName("Miltary Red 2");
        setDescription("Rank 2 in the Red Military.");
        setHP(10);
        setArmor(0);
        setStat(0, 7);
        setStat(1, 7);
        setStat(2, 7);
        setStat(3, 7);
        setStat(4, 7);
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
        return getStat(0);
    }
}
