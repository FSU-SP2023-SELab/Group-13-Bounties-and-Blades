using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryRed4 : BaseHero
{
    public MilitaryRed4()
    {
        setName("Miltary Red 4");
        setDescription("Rank 4 in the Red Military.");
        setHP(10);
        setArmor(0);
        setStat(0, 9);
        setStat(1, 7);
        setStat(2, 9);
        setStat(3, 9);
        setStat(4, 9);
        setStat(5, 9);
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
