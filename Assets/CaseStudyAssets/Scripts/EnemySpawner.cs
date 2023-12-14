using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private bool canSpawn = true;
    
    

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
