using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodedThief : BaseHero
{
    public HoodedThief()
    {
        setName("Hooded Thief");
        setDescription("Black Hood's younger and less successful brother.");
        setHP(10);
        setArmor(0);
        setStat(0, 6);
        setStat(1, 7);
        setStat(2, 4);
        setStat(3, 5);
        setStat(4, 5);
        setStat(5, 7);
    }
    public new double getDamage()
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
