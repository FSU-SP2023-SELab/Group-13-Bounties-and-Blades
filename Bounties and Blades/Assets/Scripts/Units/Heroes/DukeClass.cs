using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeClass : BaseHero
{
    public DukeClass()
    {
        setName("Duke");
        setDescription("A man of royalty! The Duke has an air of confidence and wields a sabre");
        setHP(10);
        setArmor(0);
        setStat(0, 4);
        setStat(1, 6);
        setStat(2, 5);
        setStat(3, 7);
        setStat(4, 8);
        setStat(5, 4);
    }
}
