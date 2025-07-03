using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
 
    [Header("Movimiento horizontal (X)")]
    public float velocidad = 10f;
    public Vector2 limitesX = new Vector2(-10f, 10f); // Rango permitido en X

    private float posicionYFija;
    private float posicionZFija;

    void Start()
    {
       
        posicionYFija = transform.position.y;
        posicionZFija = transform.position.z;
    }

    void Update()
    {
        float moverX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        Vector3 nuevaPos = transform.position + new Vector3(moverX, 0, 0);

        // Limitar el movimiento horizontal dentro de la pantalla
        nuevaPos.x = Mathf.Clamp(nuevaPos.x, limitesX.x, limitesX.y);

        // Mantener Y y Z fijas
        nuevaPos.y = posicionYFija;
        nuevaPos.z = posicionZFija;

        transform.position = nuevaPos;
    }
}
