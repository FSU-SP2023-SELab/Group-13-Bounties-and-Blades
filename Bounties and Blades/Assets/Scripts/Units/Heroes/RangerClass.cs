using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class RangerClass : BaseHero
{
    public RangerClass() 
    {
        setName("Ranger");
        setDescription("A skilled woodsman armed with a bow, tracking skills, and a bond with nature, guarding the wilderness from threats.");
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 6);
        setStat(2, 4);
        setStat(3, 8);
        setStat(4, 4);
        setStat(5, 5);
    }
}
