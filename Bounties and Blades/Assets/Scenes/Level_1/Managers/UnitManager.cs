using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using BountiesAndBlades.BaseHero;
using UnityEngine.SceneManagement;
using BountiesAndBlades.CharacterItems;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    public BaseHero SelectedHero;

    public GameObject SelectedObject;

    private List<GameObject> team = CharacterManager.team;

    [SerializeField]
    private List<GameObject> enemies;

    public static GameObject attacking;
    public static GameObject defending;


    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }


    public void SpawnHeroes()
    {
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

    public void SpawnEnemies()
    {
        var enemyCount = Random.Range(1,5);

        for (int i = 0; i < enemyCount; i++)
        {
            var r = Random.Range(0,enemies.Count);
            var enemyToSpawn = enemies[r];
             
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
            var ItemToSpawn = o[Random.Range(0, o.Count)];

            CharacterItems myItem = ItemToSpawn.GetComponent<CharacterItems>();

            var randomSpawnTile = GridManager.Instance.GetItemSpawnTile();

            myItem.OccupiedTile = randomSpawnTile;

            randomSpawnTile.SetItem(ItemToSpawn);
        }

        GameManager.Instance.ChangeState(GameState.HeroesTurn);
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
        attacking = att;
        defending = def;
        if(attacking == null){
             Debug.Log("Attacking was null");
        }
        if(defending == null){
            Debug.Log("defending was null");
        }
        SceneManager.LoadScene("BattleScene");
    }
}
