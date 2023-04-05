using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherClass : CharacterClass
{
    public ArcherClass()
    {
        setName("Archer");
        setDescription("Swift and great from long ditances. The archer carries a bow and wears leather armor");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 7);
        setStat(2, 3);
        setStat(3, 6);
        setStat(4, 6);
        setStat(5, 3);
    }
}
