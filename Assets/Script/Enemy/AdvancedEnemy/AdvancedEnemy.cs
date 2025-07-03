using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemy : MonoBehaviour
{
    public int health = 3;
    public int scoreValue = 100;
    public string bulletsLayer = "Bullets";
    public float velocidad = 4f;

    private bool isDead = false;
    private Vector3 direccion;

    void Start()
    {
        GameObject jugador = GameObject.Find("StarSparrow17");
        if (jugador != null)
        {
            Vector3 destino = jugador.transform.position;
            direccion = (destino - transform.position).normalized;
        }

        Destroy(gameObject, 10f); // Por si no lo matás
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer(bulletsLayer)) return;

        Destroy(other.gameObject); // Destruye la bala siempre
        health--;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            UIManagerSingleton.instance.UpdateScore(scoreValue);
            UIManagerSingleton.instance.UpdateKills();
            ProgressTracker.instance.AddKill();
            ExplosionHandler.instance.TriggerExplosion(transform.position);
            Destroy(gameObject);
        }
    }
}

