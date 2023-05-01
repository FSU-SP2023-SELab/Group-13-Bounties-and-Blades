using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BountiesAndBlades.BaseHero;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }		// states for the Battle Scene      

public class BattleSystem : MonoBehaviour
{

	private GameObject playerPrefab;	// references to our units that we will spawn in SetupBattle()
	private GameObject enemyPrefab;

	private GameObject playerGO;
	private GameObject enemyGO;

	public Transform playerBattleStation;	// references the ONLY the location on the scene we are spawning our units playerPrefab and enemyPrefab
	public Transform enemyBattleStation;

	BaseHero heroScript;	//will refereence the unit component of the gameObject which stores information about the Unit stats
	BaseHero enemyScript;

	public Text dialogueText;	//reference 

	public BattleHUD playerHUD;	// reference to the HUDs for our units that display the units information 
	public BattleHUD enemyHUD;

	public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
		state = BattleState.START;

		playerPrefab = UnitManager.attacking;
		enemyPrefab = UnitManager.defending;

		StartCoroutine(SetupBattle());	// Coroutine are functions that are running separately from anything else, which allows us to pause them when we want
		
	}

	IEnumerator SetupBattle()
		// spawn in our units
	{
		// Instantiate() spawns our playerPrefab on top of the playerBattleStation location and we store a reference to the spawned thing to playerGO
		playerGO = Instantiate(playerPrefab, new Vector3(playerBattleStation.transform.position.x,(float)(playerBattleStation.transform.position.y + .5),playerBattleStation.transform.position.z ), Quaternion.identity);	
		playerGO.transform.localScale = new Vector3(3,3,3);
		heroScript = playerGO.GetComponent<BaseHero>(); // gets unit component of the gameObject of type Unit
															// we will referencing the unit when we need information about its health, etc
		playerHUD.SetHUD(heroScript);


		enemyGO = Instantiate(enemyPrefab, new Vector3(enemyBattleStation.transform.position.x,enemyBattleStation.transform.position.y,enemyBattleStation.transform.position.z ), Quaternion.identity);
		enemyGO.transform.localScale = new Vector3(2,2,2);
		enemyScript = enemyGO.GetComponent<BaseHero>();
		enemyHUD.SetHUD(enemyScript);

		dialogueText.text = "The " + enemyScript.getName() + " stands before you";

		yield return new WaitForSeconds(2f);	// pause for 2 seconds, this is allowed because we made functions coroutines

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	// damages the enemy, then checks the enemy hp and sets the next state depending if they are dead or not
	{
		var damage = (int)heroScript.getDamage();
		bool isDead = enemyScript.TakeDamage(damage);  //TakeDamage returns true if unit hp < 0 (dead) and false if they are not dead
		//martial fighters use strength
		//magic users use intelligance
		//weird / dextrous characters use speed
		//luck * 10 / 100 is the chance to hit

		enemyHUD.SetHP(enemyScript);    //update the HP slider in the enemyHUD to display the damage they took
		if(damage > 0)
		{
			dialogueText.text = "You hit that son of a bitch!";
		}
		else{
			dialogueText.text = "You missed that son of a bitch!";
		}
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
		dialogueText.text = enemyScript.getName() + " attacks!";

		yield return new WaitForSeconds(1f);

		var damage = (int)enemyScript.getDamage();

		bool isDead = heroScript.TakeDamage(damage); //TakeDamage returns true if unit hp < 0 (dead) and false if they are not dead

		playerHUD.SetHP(heroScript); //update the HP slider in the playerHUD to display the damage they took 

		if(damage > 0)
		{
			dialogueText.text = "That son of a bitch hit you!";
		}
		else{
			dialogueText.text = "That son of a bitch missed!";
		}

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
			dialogueText.text = "You won the battle! SUCK IT!";
			Destroy(enemyGO);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
		} else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated. Dammit!";
			Destroy(playerGO);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerHeal()
	// heals the heroScript and updates the health slider
	{
		heroScript.setHP(heroScript.getHP() +  5);

		playerHUD.SetHP(heroScript);		// updates hpslider with updated hp
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
