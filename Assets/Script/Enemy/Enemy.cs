using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent onSpawn;

    public Action onDeath;
    public Action<int> onAddScore;

    public string bulletsLayer = "Bullets"; // Asegurate de tener una Layer llamada "Bullets" y asignarla a las balas
    public int scoreValue = 50; // Puntos al destruir enemigo

    void Start()
    {
        // Subscribirse a métodos del UIManager
       onDeath += UIManagerSingleton.instance.UpdateKills;
        onAddScore += UIManagerSingleton.instance.UpdateScore;

       onSpawn.AddListener(UIManagerSingleton.instance.UpdateKills);
    }

    private void OnEnable()
    {
        onSpawn?.Invoke();
    }

    private void OnDisable()
    {
       // onDeath -= UIManagerSingleton.instance.UpdateKills;
        onSpawn.RemoveAllListeners();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que colisionó está en la capa "Bullets"
        if (other.gameObject.layer != LayerMask.NameToLayer(bulletsLayer))
            return;

        print("Hit with Bullets");

        // Sumar puntaje
        onAddScore?.Invoke(scoreValue);

        // Actualizar kills
        onDeath?.Invoke();

        // Destruir al enemigo
        Destroy(this.gameObject);
    }
}
