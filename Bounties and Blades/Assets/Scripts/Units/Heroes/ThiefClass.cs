using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class ThiefClass : BaseHero
{
    public ThiefClass() 
    {
        setName("Thief");
        setDescription("A shadowy figure with keen eyes and swift movements, wielding enchanted tools to pilfer treasures from the unsuspecting.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 10);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 9);
    }
}
