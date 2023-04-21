using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BaseHero
{
    public WarriorClass()
    {
        setName("Warrior");
        setDescription("As a skilled warrior with lightning-fast reflexes and unmatched prowess in melee combat, you lead the charge against hordes of enemies.");
        setHP(10);
        setArmor(0);
        setStat(0, 7);
        setStat(1, 7);
        setStat(2, 6);
        setStat(3, 4);
        setStat(4, 8);
        setStat(5, 7);
    }
}
