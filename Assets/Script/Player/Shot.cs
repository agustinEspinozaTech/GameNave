using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Shot : MonoBehaviour
{
    private int shotFired = 0; 

    [SerializeField] private GameObject bulletOriginal;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

 
    void Update()
    {
     
        Shoot();
    }

   

    private void Shoot() 
    {
        if (Input.GetButtonDown("Jump")) 
        {
           Instantiate(bulletOriginal, bulletSpawn.position, bulletSpawn.rotation);

              shotFired++;

            if (shootSound != null && audioSource != null)
                audioSource.PlayOneShot(shootSound);
        }
    }
}
