using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterItems;

public abstract class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;

    public GameObject OccupiedObject;

    public GameObject CloneOccupiedObject;

    public int _x;
    public int _y;

    

    public bool Walkable => _isWalkable && OccupiedUnit == null;

    public bool isWalkable(){
        if (UnitManager.Instance.SelectedObject == null){
            return false;
        }
        var objToMove = UnitManager.Instance.SelectedObject;
        var heroX = objToMove.transform.position.x;
        var heroY = objToMove.transform.position.y;
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
        if(Mathf.Abs(tileX - heroX) <= speed && Mathf.Abs(tileY - heroY) <= speed){
            return true;
        }
        return false;
    } 


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        if(UnitManager.Instance.SelectedObject != null && _isWalkable && isWalkable()){
            _highlight.SetActive(true);
            MenuManager.Instance.ShowTileInfo(this);
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.HeroesTurn) return;

        if (OccupiedUnit != null) // if there is a unit to this tile
        {
            if (OccupiedUnit.Faction == Faction.Hero) 
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)OccupiedUnit, (GameObject)OccupiedObject);
            }
            else
            {
                if (UnitManager.Instance.SelectedHero != null) // we are clicking on an ememy at this point to attack them
                {
                    
                    var attacking = UnitManager.Instance.SelectedObject;
                    var defending = OccupiedObject;
                    MenuManager.Instance.deactivateUI();
                    
                    UnitManager.Instance.proceedToCombat(attacking,defending);
                    if (UnitManager.Instance.battleWon == true){
                        SetUnit(UnitManager.Instance.SelectedHero, UnitManager.Instance.SelectedObject);
                    }
                }
            }
        }
        else
        {
            if (CloneOccupiedObject != null)
            {
                CharacterItems o = CloneOccupiedObject.GetComponent<CharacterItems>();
                if (o != null)
                {
                    UnitManager.Instance.SelectedHero.addItem(o);
                    //Destroy(OccupiedObject);
                    Destroy(CloneOccupiedObject);
                }
            }
            
            if (UnitManager.Instance.SelectedHero != null && isWalkable())  // moving hero to selected tile
            {
                SetUnit(UnitManager.Instance.SelectedHero, UnitManager.Instance.SelectedObject);
                UnitManager.Instance.SetSelectedHero(null, null);
                
            }
        }

    }

    public void SetUnit(BaseUnit unit, GameObject obj)
    {
        if (unit.OccupiedTile != null) //this is when you're moving away from a tile i think -- Marconi
        {
            Destroy(unit.OccupiedTile.CloneOccupiedObject);
            //Destroy(CloneOccupiedObject);
            unit.OccupiedTile.OccupiedUnit = null;
            unit.OccupiedTile.OccupiedObject = null;
        }
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;

        BaseHero myHero = obj.GetComponent<BaseHero>();  
        myHero.Xpos = (int)transform.position.x;
        myHero.Ypos = (int)transform.position.y;
        OccupiedObject = obj;
        CloneOccupiedObject = Instantiate(obj,new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
        UnitManager.clones.Add(CloneOccupiedObject);
    }

    public void SetItem(GameObject obj)
    {
        OccupiedUnit = null;
        OccupiedObject = obj;
        CloneOccupiedObject = Instantiate(obj, new Vector3(transform.position.x, transform.position.y+1, transform.position.z - 1), Quaternion.identity);
    }

    
}
