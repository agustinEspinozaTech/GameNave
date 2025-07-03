using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletEnemyPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float shootInterval = 0.5f; // Tiempo entre disparos

    private void Start()
    {
        // Buscar el punto de disparo automáticamente si no está asignado
        if (bulletSpawnPoint == null)
        {
            bulletSpawnPoint = transform.Find("BulletSpawnPoint");

        }
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Shoot), 1f, shootInterval);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Shoot));
    }

    private void Shoot()
    {
        if (bulletSpawnPoint == null)
        {
            UnityEngine.Debug.LogWarning("[EnemyShooter] bulletSpawnPoint es null. No se puede disparar.");
            return;
        }

        GameObject bullet = Instantiate(bulletEnemyPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Ignorar colisión entre la bala y el enemigo que la dispara
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
