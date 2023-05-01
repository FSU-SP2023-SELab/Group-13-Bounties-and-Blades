using BountiesAndBlades.BaseHero;
using UnityEngine;


public abstract class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;

    public GameObject OccupiedObject;

    public GameObject CloneOccupiedObject;

    

    public bool Walkable => _isWalkable && OccupiedUnit == null;

    public bool isWalkable(){
        if (UnitManager.Instance.SelectedObject == null){
            return false;
        }
        var objToMove = UnitManager.Instance.SelectedObject;
        var unitX = objToMove.transform.position.x;
        var unitY = objToMove.transform.position.y;
        var tileX = transform.position.x;
        var tileY = transform.position.y;
        BaseHero myHeroScript = objToMove.GetComponent<BaseHero>();
        var speed = myHeroScript.getStat(1);

        //var tiles = GridManager.Instance.getTiles();

        if(!_isWalkable){ //this mmight need to change bc if it's not null you can pick up item or start battle
            return false;
        }
        if(OccupiedUnit != null){
            //if()
        }
        if(Mathf.Abs(tileX - unitX) <= speed && Mathf.Abs(tileY - unitY) <= speed){
            return true;
        }
        return false;
    } 


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    // runs when you hover over a tile
    {
        if(UnitManager.Instance.SelectedObject != null && _isWalkable && isWalkable()){
            _highlight.SetActive(true);
            MenuManager.Instance.ShowTileInfo(this);
        }
    }

    void OnMouseExit()
        //runs when you stop hovering over a tile
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }

    void OnMouseDown()
        // click logic for the game when it is players turn
    {
        if (GameManager.Instance.GameState != GameState.HeroesTurn) return; // dont execute anything if it is not player turn

        if (OccupiedUnit != null) // if there is a unit to this tile
        {
            if (OccupiedUnit.Faction == Faction.Hero) //check if the unit on clicked tile is a hero
            {
                // Select the hero on the tile so we can move with it  and attack enemies with said selected hero
                UnitManager.Instance.SetSelectedHero((BaseHero)OccupiedUnit, (GameObject)OccupiedObject);
            }
            else
            {
                if (UnitManager.Instance.SelectedHero != null) //if we have already clicked on a hero to select it then we enter this block 
                    // in this scenario with an already selectedHero then we are clicking on an enemy
                {
                    
                    var attacking = UnitManager.Instance.SelectedObject;
                    var defending = OccupiedObject;
                    
                    
                    UnitManager.Instance.proceedToCombat(attacking,defending);
                    GameManager.Instance.ChangeState(GameState.EnemiesTurn);    // after a fight you started, change to enemy turn
                }
            }
        }
        else //enter if no unit on clicked tile
        {
            if (UnitManager.Instance.SelectedHero != null && isWalkable())  // moving selected hero to empty walkable tile
            {
                SetUnit(UnitManager.Instance.SelectedHero, UnitManager.Instance.SelectedObject);
                UnitManager.Instance.SetSelectedHero(null, null);
                GameManager.Instance.ChangeState(GameState.EnemiesTurn);    // after moving one hero to a block we switch to EnemyTurn
            }
        }

    }

    public void SetUnit(BaseUnit unit, GameObject obj)
    {
        if (unit.OccupiedTile != null) //this is when you're moving away from a tile i think -- Marconi
        // if you click on a tile that has a unit, it will destroy that object 
        {
            Destroy(unit.OccupiedTile.CloneOccupiedObject);
            //Destroy(CloneOccupiedObject);
            unit.OccupiedTile.OccupiedUnit = null;
            unit.OccupiedTile.OccupiedObject = null;
        }
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;

        OccupiedObject = obj;
        CloneOccupiedObject = Instantiate(obj,new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);

    }

    
}
