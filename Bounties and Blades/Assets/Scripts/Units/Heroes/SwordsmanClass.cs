using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsmanClass : BaseHero
{
    public SwordsmanClass() 
    {
        setName("Swordsman");
        setDescription("A master swordsman, wielding a gleaming blade with unmatched skill, swift and deadly in battle, feared and respected by all.");
        setHP(10);
        setArmor(0);
        setStat(0, 6);
        setStat(1, 7);
        setStat(2, 8);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 7);
    }
}
