using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class LancerClass : BaseHero
{
    public LancerClass()
    {
        setName("Lancer");
        setDescription("Armed with his lance and mighty steed, the Lancer rides into battle. He'll poke your eye out if you get too close.");
        setArmor(0);
        setStat(0, 8);
        setStat(1, 4);
        setStat(2, 5);
        setStat(3, 5);
        setStat(4, 7);
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
