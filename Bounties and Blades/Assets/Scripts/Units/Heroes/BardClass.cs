using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class BardClass : BaseHero
{
    public BardClass()
    {
        setName("Bard");
        setArmor(0);
        setStat(0, 5);
        setStat(1, 3);
        setStat(2, 4);
        setStat(3, 7);
        setStat(4, 7);
        setStat(5, 8);
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
        return getStat(3);
    }
}
