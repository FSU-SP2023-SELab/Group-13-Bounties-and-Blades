using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterItems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    public BaseHero SelectedHero;

    public GameObject SelectedObject;

    private List<GameObject> team = CharacterManager.Instance.team;

    [SerializeField]
    private List<GameObject> enemies;

    [SerializeField]
    public static List<GameObject> clones = new List<GameObject>();

    public static List<GameObject> spawnedEnemies = new List<GameObject>(); // add spawned enemies to this enemyTeam

    public static bool herosWon = false;
    public static GameObject attacking;
    public static GameObject defending;

    public bool battleWon;
    
    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    void Update(){
        int herosAlive = 0;
        int enemiesAlive = 0;
        for(int i = 0; i < clones.Count; i++){
            if (clones[i] == null){
                continue;
            }
            BaseHero cloneScript = clones[i].GetComponent<BaseHero>();
            if (cloneScript.Faction == Faction.Hero){
                herosAlive++;
            }
            if(cloneScript.Faction == Faction.Enemy){
                enemiesAlive++;
            }
        }
        if (herosAlive == 0){
            herosWon = false;
            SceneManager.LoadScene("GameOver");
        }
        if(enemiesAlive == 0){
            herosWon = true;
            SceneManager.LoadScene("GameOver");
        }
    }


    public void SpawnHeroes()
    {
        if (GridManager.loaded == false){

            var heroCount = team.Count;

            for (int i = 0; i < heroCount; i++)
            {
                var heroToSpawn = team[i];

                BaseHero myHero = heroToSpawn.GetComponent<BaseHero>();            

                var randomSpawnTile = GridManager.Instance.GetHeroSpawnTile();

                randomSpawnTile.SetUnit(myHero, heroToSpawn);
                
            }

            GameManager.Instance.ChangeState(GameState.SpawnEnemies);
        }
    }

    public void SpawnEnemies()
    {
        var enemyCount = Random.Range(1,5);

        for (int i = 0; i < enemyCount; i++)
        {
            var r = Random.Range(0,enemies.Count);
            var enemyToSpawn = enemies[r];
            spawnedEnemies.Add(enemyToSpawn); // prefab is added
             
            BaseHero myEnemy = enemyToSpawn.GetComponent<BaseHero>(); 

            var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(myEnemy,enemyToSpawn);
        }

        GameManager.Instance.ChangeState(GameState.SpawnItems);
    }

    public void SpawnItems()
    {
        var itemCount = Random.Range(1, 3);

        for (int i = 0; i < itemCount; i++)
        {
            
            List<GameObject> o = Resources.LoadAll<GameObject>("").ToList();
            int index = Random.Range(0, o.Count);
            var ItemToSpawn = o[index];

            CharacterItems myItem = ItemToSpawn.GetComponent<CharacterItems>();

            var randomSpawnTile = GridManager.Instance.GetItemSpawnTile();

            myItem.OccupiedTile = randomSpawnTile;

            randomSpawnTile.SetItem(ItemToSpawn, index);
        }

        GameManager.Instance.ChangeState(GameState.HeroesTurn);
    }

    public void EnemyTurn()
    // in the enemy turn, we want to selected an enemy that is not dead for the nearest hero unit to them, and move as close to them
    // based on the selected enemies speed stat
    {
        Debug.Log("Entering EnemyTurn function");
        //GameObject selectedEnemy; // this will be the enemy unit to move

        bool canFight = false;

        /*
        for(int i = 0; i< clones.Count; i++)
        {
            if (clones[i] == null)
                continue;
            BaseHero cloneScript = clones[i].GetComponent<BaseHero>();
            if(cloneScript.Faction == Faction.Enemy)
                enemyClones.Add(clones[i]);
            if (cloneScript.Faction == Faction.Hero)
                heroClones.Add(clones[i]);

        }*/


        var selectedEnemy = clones[0];
        var selectedHero = clones[0];

        for (int i = 0; i < clones.Count; i++)
        {

            if (clones[i] == null)
                continue;
            BaseHero cloneScript = clones[i].GetComponent<BaseHero>();
            if (cloneScript.Faction == Faction.Enemy)
                selectedEnemy = clones[i];
            if (cloneScript.Faction == Faction.Hero)
                selectedHero = clones[i];
            
            /*
            for (int j = 0; j < heroClones.Count; j++)
            {
                selectedHero = heroClones[j];

                var unitX = selectedEnemy.transform.position.x;
                var unitY = selectedEnemy.transform.position.y;
                var tileX = selectedHero.transform.position.x;
                var tileY = selectedHero.transform.position.y;
                BaseHero enemyScript = selectedEnemy.GetComponent<BaseHero>();
                var enemySpeed = enemyScript.getStat(1);

                if (Mathf.Abs(tileX - unitX) <= enemySpeed && Mathf.Abs(tileY - unitY) <= enemySpeed) // if hero is within their range
                {
                    canFight = true;
                    break;
                }

            }*/
            if (canFight)
                break;
        }

        if (canFight)
            UnitManager.Instance.proceedToCombat(selectedHero, selectedEnemy);

        GameManager.Instance.ChangeState(GameState.HeroesTurn); // change to heroes turn at the end 

        //for(int i = 0; i < enemyTeam.Count; i++)
        // gets first enemy in enemy Team
        //{
        //    if(enemyTeam[i] != null) // null check for safety reasons
        //    {
        //        selectedEnemy = enemyTeam[i];
        //       break;
        //    }
        //}

        //var unitX = selectedEnemy.transform.position.x;
        //var unitY = selectedEnemy.transform.position.y;
        //var tileX = selectedHero.transform.position.x;
        //var tileY = selectedHero.transform.position.y;
        //BaseHero enemyScript = selectedEnemy.GetComponent<BaseHero>();
        //var enemySpeed = enemyScript.getStat(1);


        //if (Mathf.Abs(tileX - unitX) <= enemySpeed && Mathf.Abs(tileY - unitY) <= enemySpeed) // if hero is within their range
        //{
        //   UnitManager.Instance.proceedToCombat(selectedHero, selectedEnemy);
        //}
        //else // if hero is too far
        //{
        //
        //}

        //GameManager.Instance.ChangeState(GameState.HeroesTurn); // change to heroes turn at the end 
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        // going through our list, wanting all of the units according to the faction that we want, then shuffling them around and getting
        // just the first unitPrefab instead of the entire scriptable unit
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedHero(BaseHero hero, GameObject obj)
    {
        SelectedObject = obj;
        SelectedHero = hero;
        MenuManager.Instance.ShowSelectedHero(hero);
    }

    public void proceedToCombat(GameObject att, GameObject def){
        battleWon = false;
        attacking = att;
        defending = def;
        if(attacking == null){
             Debug.Log("Attacking was null");
        }
        if(defending == null){
            Debug.Log("defending was null");
        }
        AudioListener audioListener = FindObjectOfType<AudioListener>();
        audioListener.enabled = false;

        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }

    public void battleFinished(bool heroWon, string aliveName, string diedName, int health){
        //removing the dead person from map
        for (int i = 0; i < clones.Count; i++){
            GameObject g = clones[i];
            if(g == null){
                continue;
            }

            if(g.name == diedName){
                clones.Remove(g);
                Destroy(g);
                break;
            }
        }
        //setting the alive person's health 
        for (int i = 0; i < clones.Count; i++){
            GameObject g = clones[i];
            if(g == null){
                continue;
            }

            if(g.name == aliveName){
                BaseHero heroScript = g.GetComponent<BaseHero>(); 
                heroScript.setHP(health);
                break;
            }
        }
        //have to turn the audioListener back on
        AudioListener audioListener = FindObjectOfType<AudioListener>();
        audioListener.enabled = true;

        //make the selected person/hero null
        SelectedHero = null;
        SelectedObject = null;
    }

    public int getHPByName(string name){
        for (int i = 0; i < clones.Count; i++){
            GameObject g = clones[i];
            if(g == null){
                continue;
            }

            if(g.name == name){
                BaseHero script = g.GetComponent<BaseHero>(); 
                return script.getHP();
            }
        }
        return 0;
    }
}
