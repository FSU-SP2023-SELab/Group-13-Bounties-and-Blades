using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldy : BaseHero
{

    public Baldy() 
    {
        setName("Baldy");
        setDescription("Bald.");
        setHP(10);
        setArmor(0);
        setStat(0, 6);
        setStat(1, 5);
        setStat(2, 6);
        setStat(3, 5);
        setStat(4, 4);
        setStat(5, 5);
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
