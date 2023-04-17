using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.CharacterClass;
using BountiesAndBlades.CharacterStats;

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
        // List<StatModifier> mods = archer.getModifiers();
        // GUILayout.Label(archer.getName());
        // foreach (StatModifier s in mods)
        // {
        //     GUILayout.Label(s.ToString());
        // }
        // archer2.addModifier(new BountiesAndBlades.CharacterStats.StatModifier(100, new BountiesAndBlades.CharacterStats.StatModType(), 1, 0));
        // GUILayout.Label(archer2.getName());
        // mods = archer2.getModifiers();
        // foreach (StatModifier s in mods)
        // {
        //     GUILayout.Label(s.ToString());
        // }
    }
}
