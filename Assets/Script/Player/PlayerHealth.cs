using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float invulnerableTime = 2f;

    private int currentLives;
    private bool isInvulnerable = false;
    private Renderer rend;

    void Start()
    {
        currentLives = maxLives;
        rend = GetComponent<Renderer>();

        // Mostrar vidas al inicio
        UIManagerSingleton.instance.SetLives(currentLives);
    }

    void OnTriggerEnter(Collider other)
    {
        // Si está invulnerable, ignora el impacto
        if (isInvulnerable) return;

        // Verifica si lo tocó una bala enemiga o una nave enemiga
        if (other.gameObject.layer == LayerMask.NameToLayer("BulletsEnemy") ||
            other.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        currentLives--;

        // Actualizar UI
        UIManagerSingleton.instance.SetLives(currentLives);

        if (currentLives <= 0)
        {
            UnityEngine.Debug.Log("Jugador destruido");
            UIManagerSingleton.instance.ShowGameOver(); //Quiere decir que se ha perdido el juego
            Time.timeScale = 0f; //Congela el juego cuando pierde todas las vidas
            Destroy(this.gameObject);
        }
        else
        {
            UnityEngine.Debug.Log("Vida perdida. Vidas restantes: " + currentLives);
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        float blinkTime = 0.2f;
        float elapsed = 0f;

        while (elapsed < invulnerableTime)
        {
            if (rend != null) rend.enabled = !rend.enabled;
            yield return new WaitForSeconds(blinkTime);
            elapsed += blinkTime;
        }

        if (rend != null) rend.enabled = true;
        isInvulnerable = false;
    }
}
