using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	// variables describing our unit 
	// Player and enemy share this script 
	public string unitName;
	public int unitLevel;		

	public int damage; //damage they'll be able to do

	public int maxHP;
	public int currentHP;

	public bool TakeDamage(int dmg)	
	// subtracts dmg from our currentHP and returns true if we die and false if we havent died
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	// increase our hp by amount
	{
		currentHP += amount;
		if (currentHP > maxHP)	//if currentHp surpassed maxHp, set currentHP to maxHP
			currentHP = maxHP;
	}

}
