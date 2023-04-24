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
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 7);
        setStat(2, 5);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 6);
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
