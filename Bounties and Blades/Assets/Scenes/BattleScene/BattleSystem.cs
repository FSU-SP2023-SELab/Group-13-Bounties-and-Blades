using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }		// states for the Battle Scene      

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;	// references to our units that we will spawn in SetupBattle()
	public GameObject enemyPrefab;

	public Transform playerBattleStation;	// references the ONLY the location on the scene we are spawning our units playerPrefab and enemyPrefab
	public Transform enemyBattleStation;

	Unit playerUnit;	//will refereence the unit component of the gameObject which stores information about the Unit stats
	Unit enemyUnit;

	public Text dialogueText;	//reference 

	public BattleHUD playerHUD;	// reference to the HUDs for our units that display the units information 
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;
		StartCoroutine(SetupBattle());	// Coroutine are functions that are running separately from anything else, which allows us to pause them when we want
    }

	IEnumerator SetupBattle()
		// spawn in our units
	{
		// Instantiate() spawns our playerPrefab on top of the playerBattleStation location and we store a reference to the spawned thing to playerGO
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);	
		playerUnit = playerGO.GetComponent<Unit>(); // gets unit component of the gameObject of type Unit
													// we will referencing the unit when we need information about its health, etc

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(2f);	// pause for 2 seconds, this is allowed because we made functions coroutines

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	// damages the enemy, then checks the enemy hp and sets the next state depending if they are dead or not
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);  //TakeDamage returns true if unit hp < 0 (dead) and false if they are not dead
		//martial fighters use strength
		//magic users use intelligance
		//weird / dextrous characters use speed
		//luck * 10 / 100 is the chance to hit

		enemyHUD.SetHP(enemyUnit.currentHP);    //update the HP slider in the enemyHUD to display the damage they took
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if(isDead)
		{
			state = BattleState.WON;
			EndBattle();
		} else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	// this function just makes the enemy attack everytime for now but we can further develop this if we want
	{
		dialogueText.text = enemyUnit.unitName + " attacks!";

		yield return new WaitForSeconds(1f);

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage); //TakeDamage returns true if unit hp < 0 (dead) and false if they are not dead

		playerHUD.SetHP(playerUnit.currentHP); //update the HP slider in the playerHUD to display the damage they took 

		yield return new WaitForSeconds(1f);

		if(isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		} else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
		//simply updates the dialog text of the dialoguePanel
		// may have to turn this into coroutine to switch back to our game scene
	{
		if(state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	// heals the playerUnit and updates the health slider
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);		// updates hpslider with updated hp
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	// want to trigger this whenever the attack button is pressed for the player unit
	// make public to be able to do this through the UI
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	// want to trigger this whenever the heal button is pressed for the player unit
	// make public to be able to do this through the UI
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

}
