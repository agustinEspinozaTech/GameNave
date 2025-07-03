using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private bool isDead = false;

    public UnityEvent onSpawn;

    public Action onDeath;
    public Action<int> onAddScore;

    public string bulletsLayer = "Bullets";
    public int scoreValue = 50;

    public float velocidad = 5f;
    private Vector3 direccion;

    void Start()
    {
        onDeath += UIManagerSingleton.instance.UpdateKills;
        onAddScore += UIManagerSingleton.instance.UpdateScore;

        GameObject jugador = GameObject.Find("StarSparrow17");
        if (jugador != null)
        {
            Vector3 destino = jugador.transform.position;
            direccion = (destino - transform.position).normalized;
        }

        Destroy(gameObject, 5f);
    }

    private void OnEnable()
    {
        onSpawn?.Invoke();
    }

    private void OnDisable()
    {
        onSpawn.RemoveAllListeners();
    }

    private void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer(bulletsLayer))
            return;

        if (isDead) return; 
        isDead = true;

        onAddScore?.Invoke(scoreValue);
        ProgressTracker.instance.AddKill();
        onDeath?.Invoke();
        ProgressTracker.instance.AddKill();
        ExplosionHandler.instance.TriggerExplosion(transform.position);
        Destroy(this.gameObject);
    }
}
