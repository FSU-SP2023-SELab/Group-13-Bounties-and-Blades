using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public List<GameObject> team = new List<GameObject>();

    public void Add(GameObject g){
        team.Add(g);
    }
}
