using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LutePlayerClass : BaseHero
{
    public LutePlayerClass()
    {
        setName("Lute Player");
        setDescription("The Lute Player can lure enemies in with sweet melodies and pierce them with shrieking chords. He can play the lute ... and ... that's it.");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 6);
        setStat(2, 4);
        setStat(3, 8);
        setStat(4, 7);
        setStat(5, 6);
    }
}