using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BountiesAndBlades.BaseHero;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedHeroObject, _tileObject, _tileUnitObject;

    [SerializeField] private GameObject _eventListener;

    void Awake()
    {
        Instance = this;
    }

    public void deactivateUI(){
        AudioListener audioListener = FindObjectOfType<AudioListener>();
        _selectedHeroObject.SetActive(false);
        _tileObject.SetActive(false);
        _tileUnitObject.SetActive(false);
        _eventListener.SetActive(false);
    }

    public void activateUI(){
        _selectedHeroObject.SetActive(true);
        _tileObject.SetActive(true);
        _tileUnitObject.SetActive(true);
        _eventListener.SetActive(false);
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
}
