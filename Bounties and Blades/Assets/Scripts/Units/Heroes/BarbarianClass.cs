using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class BarbarianClass : BaseHero
{
    public BarbarianClass()
    {
        setName("Barbarian");
        setDescription("The Barbarian smashes his way through enemies with ease. Strong but effective, carries a club.");
        setHP(10);
        setArmor(0);
        setStat(0, 9);
        setStat(1, 3);
        setStat(2, 8);
        setStat(3, 4);
        setStat(4, 6);
        setStat(5, 3);
    }
}
