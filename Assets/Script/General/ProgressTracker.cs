using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker instance;
    private bool hasWon = false;

    [Header("Progreso del jugador")]
    public int currentKills = 0;
    public float gameTime = 0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        gameTime += Time.deltaTime; // Acumula el tiempo total de juego
        CheckVictoryCondition();
    }

    public void AddKill()
    {
        currentKills++; // Suma una kill real del jugador

    }

    public int GetKills()
    {
        return currentKills;
    }

    public float GetGameTime()
    {
        return gameTime;
    }

    private void CheckVictoryCondition()
    {
        if (!hasWon && gameTime >= 60f) // 300f para 5 minutos reales
        {
            hasWon = true;

            // Destruir todos los enemigos por layer
            int enemyLayer = LayerMask.NameToLayer("Enemies");
            GameObject[] todos = FindObjectsOfType<GameObject>();
            foreach (GameObject go in todos)
            {
                if (go.activeInHierarchy && go.layer == enemyLayer)
                {
                    Destroy(go);
                }
            }

            // Mostrar pantalla de victoria
            UIManagerSingleton.instance.ShowVictory();

            
             Time.timeScale = 0f; 
        }
    }
}
