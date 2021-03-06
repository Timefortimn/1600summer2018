﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnLocation;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (numberOfEnemies > 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                var spawnPosition = spawnLocation.transform.position +
                                    new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, Random.Range(-8.0f, 8.0f));
                var spawnRotation = Quaternion.Euler(0.0f, Random.Range(0, 180), 0.0f);
                var enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
                NetworkServer.Spawn(enemy);
            }

            numberOfEnemies--;
            
            yield return new WaitForSeconds(5);
        }
        
    }
    
}