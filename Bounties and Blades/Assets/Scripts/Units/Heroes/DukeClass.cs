using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class DukeClass : BaseHero
{
    public DukeClass()
    {
        setName("Duke");
        setDescription("A man of royalty! The Duke has an air of confidence and wields a sabre");
        setArmor(0);
        setStat(0, 4);
        setStat(1, 3);
        setStat(2, 5);
        setStat(3, 7);
        setStat(4, 8);
        setStat(5, 6);
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
