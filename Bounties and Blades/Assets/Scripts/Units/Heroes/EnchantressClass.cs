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
        setArmor(0);
        setStat(0, 4);
        setStat(1, 5);
        setStat(2, 6);
        setStat(3, 7);
        setStat(4, 6);
        setStat(5, 8);
        var hp = 10 + (int)getStat(4);
        setHP(hp);
        setMaxHP(hp);
    }
    public override double getDamage()
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
