using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyMovement : MonoBehaviour
{
   
    public float velocidad = 5f;
    public float frecuencia = 3f;
    public float amplitud = 1f;

    private Vector3 direccion;
    private Vector3 posicionInicial;
    private float tiempo;

    void Start()
    {
        GameObject jugador = GameObject.FindWithTag("Player");
        if (jugador != null)
        {
            direccion = (jugador.transform.position - transform.position).normalized;
        }

        posicionInicial = transform.position;
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        Vector3 offset = transform.right * Mathf.Sin(tiempo * frecuencia) * amplitud;
        transform.position += (direccion * velocidad * Time.deltaTime) + offset * Time.deltaTime;
    }
}
