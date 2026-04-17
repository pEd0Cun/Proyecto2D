using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] int nivelACargar = 1;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(nivelACargar);

    }public void CerrarAplicacion()
    {
        Application.Quit();

    }
}
