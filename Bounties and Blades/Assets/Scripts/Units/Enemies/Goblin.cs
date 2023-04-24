using BountiesAndBlades.BaseHero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : BaseHero
{
    public Goblin()
    {
        setName("Goblin");
        setDescription("Gobbling.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 7);
        setStat(2, 4);
        setStat(3, 7);
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
        return getStat(1);
    }
}
