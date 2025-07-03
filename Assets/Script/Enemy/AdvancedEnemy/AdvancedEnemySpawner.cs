using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AdvancedEnemySpawner : MonoBehaviour
{
    public GameObject advancedEnemyPrefab;
    public Transform[] spawnPoints;
    public float repeatInterval = 5f;


    void Start()
    {
        StartCoroutine(CheckConditionsAndSpawn());
    }

    IEnumerator CheckConditionsAndSpawn()
    {
        // Esperar hasta que se cumplan las condiciones para la primera aparición
        while (!CanSpawnAdvancedEnemies())
        {
            yield return new WaitForSeconds(1f);
        }

        // Primera aparición
        SpawnEnemies();

        // Luego de la primera vez, repetir cada X segundos
        while (true)
        {
            yield return new WaitForSeconds(repeatInterval);
            SpawnEnemies();
        }
    }

    bool CanSpawnAdvancedEnemies()
    {
        return ProgressTracker.instance != null &&
               ProgressTracker.instance.currentKills >= 5 &&
               ProgressTracker.instance.gameTime >= 30f;
    }

    void SpawnEnemies()
    {
        foreach (Transform point in spawnPoints)
        {
            Instantiate(advancedEnemyPrefab, point.position, point.rotation);
        }
    }
}