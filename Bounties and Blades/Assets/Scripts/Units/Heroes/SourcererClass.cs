using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class SourcererClass : BaseHero
{
    public SourcererClass()
    {
        setName("Sourcerer");
        setDescription("A sorcerer of dark arts, wielding forbidden spells, with a staff crackling with arcane energy, and eyes ablaze with malevolent power.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 5);
        setStat(2, 3);
        setStat(3, 10);
        setStat(4, 5);
        setStat(5, 7);
    }
}
