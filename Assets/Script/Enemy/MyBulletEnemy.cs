using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Velocidad de la bala del enemigo
    [SerializeField] private float lifeTime = 5f; // Tiempo de vida de la bala

    private void OnEnable()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(this.gameObject); // Destruye la bala al colisionar con el jugador
        }
    }

    private void OnDisable()
    {
        CancelInvoke("DestroyBullet");
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
