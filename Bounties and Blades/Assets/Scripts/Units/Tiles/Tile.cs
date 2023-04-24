using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;


    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
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
            if (OccupiedUnit.Faction == Faction.Hero) UnitManager.Instance.SetSelectedHero((BaseHero)OccupiedUnit);
            else
            {
                if (UnitManager.Instance.SelectedHero != null) // we are clicking on an ememy at this point to attack them
                {
                    // delete the enemy as soon as we click on it
                    var enemy = (BaseEnemy)OccupiedUnit;        
                    Destroy(enemy.gameObject);                      // should be doing combat stuff here such as calculating damage
                    UnitManager.Instance.SetSelectedHero(null);
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null)  // moving hero to selected tile
            {
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedHero(null);
            }
        }

    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
*/