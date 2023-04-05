using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterClass;
public class TestGUI : MonoBehaviour
{
    private CharacterClass archer = new ArcherClass();
    private CharacterClass archer2 = new ArcherClass();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        string[,] mods = archer.getModifiers();
        GUILayout.Label(archer.getName());
        int modLength = mods.GetLength(1);
        for (int i = 0; i < modLength; i++)
        {
            GUILayout.Label(archer.getModifiers()[0, i] +", "+ archer.getModifiers()[1, i]);
        }
        archer2.addModifier(new BountiesAndBlades.CharacterStats.StatModifier(100, new BountiesAndBlades.CharacterStats.StatModType(), 1, 0));
        GUILayout.Label(archer2.getName());
        mods = archer2.getModifiers();
        modLength = mods.GetLength(1);
        for (int i = 0; i < modLength; i++)
        {
            GUILayout.Label(archer2.getModifiers()[0, i] + ", " + archer2.getModifiers()[1, i]);
        }
    }
}
