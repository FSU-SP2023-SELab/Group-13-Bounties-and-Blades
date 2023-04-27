using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class BarbarianClass : BaseHero
{
    public BarbarianClass()
    {
        setName("Barbarian");
        setDescription("The Barbarian smashes his way through enemies with ease. Strong but effective, carries a club.");
        setArmor(0);
        setStat(0, 9);
        setStat(1, 2);
        setStat(2, 8);
        setStat(3, 4);
        setStat(4, 6);
        setStat(5, 3);
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
