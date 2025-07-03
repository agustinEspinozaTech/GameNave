using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    
    public GameObject panelHistoria;
    public GameObject panelMenu;

    void Start()
    {
        panelHistoria.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void Continuar()
    {
        panelHistoria.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Juego"); 
    }
}
