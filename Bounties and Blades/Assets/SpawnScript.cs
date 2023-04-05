using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawnArray;
    void Start()
    {
        int number = Random.Range(0,spawnArray.Length);
        Instantiate(spawnArray[number], this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
