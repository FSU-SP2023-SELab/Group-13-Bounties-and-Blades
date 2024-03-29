using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class MageClass : BaseHero
{
    public MageClass()
    {
        setName("Mage");
        setDescription("The mage, draped in a long robe adorned with glowing runes, wielded the power to bend reality to their will.");
        setArmor(0);
        setStat(0, 7);
        setStat(1, 3);
        setStat(2, 6);
        setStat(3, 8);
        setStat(4, 6);
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
        return getStat(3);
    }
}
