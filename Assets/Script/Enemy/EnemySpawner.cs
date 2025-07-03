using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform[] puntosDeSpawn;
    public float intervaloSpawn = 2f;
    public float esperaEntreLotes = 5f;
    public string enemyLayerName = "Enemy";

    private int enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer(enemyLayerName);
        StartCoroutine(CicloDeSpawn());
    }

    IEnumerator CicloDeSpawn()
    {
        while (true)
        {
            for (int i = 0; i < puntosDeSpawn.Length; i++)
            {
                SpawnEnemigo(puntosDeSpawn[i]);
                yield return new WaitForSeconds(intervaloSpawn);
            }

            yield return StartCoroutine(EsperarHastaQueNoHayaEnemigos());
            yield return new WaitForSeconds(esperaEntreLotes);
        }
    }

    void SpawnEnemigo(Transform punto)
    {
        if (enemigoPrefab != null && punto != null)
        {
            Instantiate(enemigoPrefab, punto.position, punto.rotation);
        }
    }

    IEnumerator EsperarHastaQueNoHayaEnemigos()
    {
        while (true)
        {
            GameObject[] todos = FindObjectsOfType<GameObject>();
            bool hayEnemigos = false;

            foreach (GameObject go in todos)
            {
                if (go.activeInHierarchy && go.layer == enemyLayer)
                {
                    hayEnemigos = true;
                    break;
                }
            }

            if (!hayEnemigos)
                break;

            yield return null;
        }
    }
}
