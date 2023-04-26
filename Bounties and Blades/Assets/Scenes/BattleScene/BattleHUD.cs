using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
	// script for the BattleHUD for each unit we spawn in that displays their stats
	// battleSystem will have references to each battleHUD
{

	public Text nameText;	// refernces to the objects on the UI for the HUD
	public Text levelText;
	public Slider hpSlider;

	public void SetHUD(Unit unit)
	// pass in the Unit to have access to all the information we need and set the UI objects to them
	{
		nameText.text = unit.unitName;
		levelText.text = "Lvl " + unit.unitLevel;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
	}

	public void SetHP(int hp)
	// function to update the hp throughout the battle
	{
		hpSlider.value = hp;
	}

}
