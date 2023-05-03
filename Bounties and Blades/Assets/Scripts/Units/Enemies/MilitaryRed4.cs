using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryRed4 : BaseHero
{
    public MilitaryRed4()
    {
        setName("Sergeant Major");
        setDescription("Rank 4 in the Red Military.");
        setArmor(0);
        setStat(0, 9);
        setStat(1, 7);
        setStat(2, 9);
        setStat(3, 9);
        setStat(4, 9);
        setStat(5, 5);
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
