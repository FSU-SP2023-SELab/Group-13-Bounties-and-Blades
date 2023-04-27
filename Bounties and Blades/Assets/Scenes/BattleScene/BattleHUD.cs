using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BountiesAndBlades.BaseHero;
using TMPro;

public class BattleHUD : MonoBehaviour
	// script for the BattleHUD for each unit we spawn in that displays their stats
	// battleSystem will have references to each battleHUD
{

	public Text nameText;	// refernces to the objects on the UI for the HUD
	//public Text levelText;
	public TextMeshProUGUI currentHP;
	public TextMeshProUGUI maxHP;

	public void SetHUD(BaseHero unit)
	// pass in the Unit to have access to all the information we need and set the UI objects to them
	{
		nameText.text = unit.getName();
		//levelText.text = "Lvl " + unit.unitLevel;
		maxHP.text = unit.getMaxHP().ToString();
		currentHP.text = unit.getHP().ToString();
	}

	public void SetHP(BaseHero unit)
	// function to update the hp throughout the battle
	{
		currentHP.text = unit.getHP().ToString();
	}

}
