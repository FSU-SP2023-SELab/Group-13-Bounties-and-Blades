using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardClass : BaseHero
{
    public BardClass()
    {
        setName("Bard");
        setDescription("Weaves his way into an enemy's psyche with imposing wordplay. The Bard speaks softly and carries a big stick.");
        setHP(10);
        setArmor(0);
        setStat(0, 5);
        setStat(1, 5);
        setStat(2, 4);
        setStat(3, 7);
        setStat(4, 7);
        setStat(5, 6);
    }
}
