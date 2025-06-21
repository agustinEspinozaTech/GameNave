using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Shot : MonoBehaviour
{
    private int shotFired = 0; // Counter for shots fired

    [SerializeField] private GameObject bulletOriginal;
    [SerializeField] private Transform bulletSpawn;



    // Update is called once per frame
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
        }
    }
}
