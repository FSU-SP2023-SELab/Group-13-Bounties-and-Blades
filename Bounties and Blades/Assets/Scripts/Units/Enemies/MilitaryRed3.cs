using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryRed3 : BaseHero
{
    public MilitaryRed3()
    {
        setName("Gunnery Sergeant");
        setDescription("Rank 3 in the Red Military.");
        setArmor(0);
        setStat(0, 8);
        setStat(1, 6);
        setStat(2, 8);
        setStat(3, 8);
        setStat(4, 8);
        setStat(5, 4);
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
