using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Speed of the bullet
    [SerializeField] private float lifeTime = 5f; // Lifetime of the bullet in seconds

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
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Destroy(this.gameObject); // Destruye la bala al colisionar
        }
    }


    private void OnDisable()
    {
        CancelInvoke("DestroyBullet");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
