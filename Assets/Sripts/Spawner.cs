using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<Transform> SpawnPoint = new List<Transform>();
    public List<GameObject> Enemies = new List<GameObject>();
    public int Min;
    public int Max;

    void Start()
    {

        if (Max > SpawnPoint.Count)
            Max = SpawnPoint.Count;
        
        int spawnerCount = Random.Range(Min, Max);
        int typeOfEnemy;

        for(int i = 0; i <= spawnerCount; i++)
        {
            typeOfEnemy = Random.Range(0, Enemies.Count);
            Instantiate(Enemies[typeOfEnemy], SpawnPoint[i]);
        }
    }
}
