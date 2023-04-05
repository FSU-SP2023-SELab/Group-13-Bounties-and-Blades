using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn : MonoBehaviour//, IPointerClickHandler
{
    public GameObject[] spawnArray;
    public GameObject spawned;
    [SerializeField] Team team;
    void Start()
    {
        spawned = spawnArray[Random.Range(0, spawnArray.Length)];
        Instantiate(spawned, this.transform);
    }

    void Awake(){
        team = GetComponent<Team>();
    }
    public void AddToTeam(){
        Debug.Log("Clicked");
        team.Add(spawned);
    }
    // public void OnPointerClick(PointerEventData eventData){
    //     Debug.Log("Clicked");
    //     AddToTeam();
    // }

}
