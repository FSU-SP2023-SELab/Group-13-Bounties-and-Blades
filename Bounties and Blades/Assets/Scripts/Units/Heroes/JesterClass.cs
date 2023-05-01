using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class JesterClass : BaseHero
{
    public JesterClass()
    {
        setName("Jester");
        setDescription("The Jester is the life of the party! He is equipped with his juggling balls and an arsenal of jokes.");
        setArmor(0);
        setStat(0, 3);
        setStat(1, 4);
        setStat(2, 3);
        setStat(3, 8);
        setStat(4, 5);
        setStat(5, 10);
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
        return getStat(1);
    }

}
