using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _mountainTile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    public static List<Tile> tileList = new List<Tile>();

    public static bool loaded = false;

    public bool hasLoaded(){
        if (tileList.Count > 0){
            return true;
        }
        return false;
    }

    public Dictionary<Vector2, Tile> getTiles(){
        return _tiles;
    }


    void Awake()
    {
        Instance = this;
    }

    private void Update() {
        
    }

    public void GenerateGrid()
    {
        Debug.Log("Entered GenerateGrid() function in GridManager");
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = Random.Range(0, 6) == 3 ? _mountainTile : _grassTile;
                tileList.Add(randomTile);
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y, -1), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";


                spawnedTile.Init(x, y);
            
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
        
    }

    public Tile GetHeroSpawnTile()
    {
        // makes heroes spawn to the left 
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        // makes enemies spawn to the right
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetItemSpawnTile()
    {
       
        return _tiles.Where(t => t.Value.OccupiedObject == null && t.Value.OccupiedUnit == null && t.Value.GetComponent<GrassTile>()).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}