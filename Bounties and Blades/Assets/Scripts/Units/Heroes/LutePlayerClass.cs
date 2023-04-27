using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;

public class LutePlayerClass : BaseHero
{
    public LutePlayerClass()
    {
        setName("Lute Player");
        setDescription("The Lute Player can lure enemies in with sweet melodies and pierce them with shrieking chords. He can play the lute ... and ... that's it.");
        setArmor(0);
        setStat(0, 4);
        setStat(1, 4);
        setStat(2, 4);
        setStat(3, 8);
        setStat(4, 7);
        setStat(5, 6);
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
        return getStat(1);
    }
}
