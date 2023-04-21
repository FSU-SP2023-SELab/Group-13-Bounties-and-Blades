using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class RogueClass : BaseHero
{
    public RogueClass()
    {
        setName("Rogue");
        setDescription("A cunning and elusive rogue with a sharp wit, quick reflexes, and a penchant for thievery and sabotage.");
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 9);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 7);
        setStat(5, 8);
    }
}
