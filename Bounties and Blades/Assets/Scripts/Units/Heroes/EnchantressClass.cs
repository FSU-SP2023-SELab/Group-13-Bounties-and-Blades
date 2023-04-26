using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class EnchantressClass : BaseHero
{
    public EnchantressClass()
    {
        setName("Enchantress");
        setDescription("Don't get too close or you'll be entrapped by her dark spells. The Enchantress uses magic to banish enemies to the shadow realm.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 5);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 7);
    }
    public new double getDamage()
    {

        double randomNumber = Random.Range(1, 101);
        double chanceToHit = getStat(5) * 10;
        if (randomNumber > chanceToHit)
        {
            return 0;
        }
        return getStat(3);
    }
}
