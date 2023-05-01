using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BountiesAndBlades.BaseHero;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedHeroObject, _tileObject, _tileUnitObject, _unitInfo1, _unitInfo2, _unitInfo3, _unitInfo4, 
                                        _unitInfo5, _unitInfo6 , _unitInfo7;


    void Awake()
    {
        Instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {

        if (tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        _tileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }

        _selectedHeroObject.GetComponentInChildren<Text>().text = hero.UnitName;
        _selectedHeroObject.SetActive(true);
    }

    public void ShowUnitsSpeed(BaseHero heroes) // send in the list of the units on the screen and then have them set to _unitInfox depending on their speed stat
    {
        if (heroes == null)
        {
            _selectedHeroObject.SetActive(false);
            return;
        }

        _unitInfo1.GetComponentInChildren<Text>().text = heroes.getStat(1).ToString();
        _unitInfo1.SetActive(true);
    }
}
