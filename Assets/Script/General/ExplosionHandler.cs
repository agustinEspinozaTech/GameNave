using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    public static ExplosionHandler instance;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioClip explosionSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerExplosion(Vector3 position)
    {
        if (explosionPrefab != null)
        {
            GameObject fx = Instantiate(explosionPrefab, position, Quaternion.identity);
            Destroy(fx, 0.8f);
        }

        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, position);
        }
    }
}
