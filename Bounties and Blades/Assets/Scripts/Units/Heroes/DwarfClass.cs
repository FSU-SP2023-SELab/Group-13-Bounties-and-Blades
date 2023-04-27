using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class DwarfClass : BaseHero
{
    public DwarfClass()
    {
        setName("Dwarf");
        setDescription("Small and cunning, the dwarf will make quick work of any enemies. Armed with a blade and quick to the draw.");
        setArmor(0);
        setStat(0, 8);
        setStat(1, 2);
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
