using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class MageClass : BaseHero
{
    public MageClass()
    {
        setName("Mage");
        setDescription("The mage, draped in a long robe adorned with glowing runes, wielded the power to bend reality to their will.");
        setHP(10);
        setArmor(0);
        setStat(0, 7);
        setStat(1, 7);
        setStat(2, 6);
        setStat(3, 8);
        setStat(4, 6);
        setStat(5, 4);
    }
}
