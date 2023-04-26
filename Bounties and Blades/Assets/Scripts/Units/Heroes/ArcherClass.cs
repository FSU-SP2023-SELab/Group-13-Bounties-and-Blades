using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class ArcherClass : BaseHero
{
    public ArcherClass()
    {
        setName("Archer");
        setDescription("Swift and great from long ditances. The archer carries a bow and wears leather armor");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 5);
        setStat(2, 3);
        setStat(3, 6);
        setStat(4, 6);
        setStat(5, 3);
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
