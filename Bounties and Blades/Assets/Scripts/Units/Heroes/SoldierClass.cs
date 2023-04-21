using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class SoldierClass : BaseHero
{
    public SoldierClass()
    {
        setName("Soldier");
        setDescription("The soldier is a strong ass mf.");
        setHP(10);
        setArmor(0);
        setStat(0, 10);
        setStat(1, 2);
        setStat(2, 9);
        setStat(3, 2);
        setStat(4, 7);
        setStat(5, 3);
    }
}
