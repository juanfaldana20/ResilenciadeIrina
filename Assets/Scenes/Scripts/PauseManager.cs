using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
     public GameObject pausaCanvas;
    private bool isPaused = false;

    void Start()
    {
        pausaCanvas.SetActive(false);
    }

    void Update()
    {
        // Comprueba si la tecla "P" ha sido presionada para pausar o reanudar el juego.
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePausa();
        }

        // Comprueba si el botón "A" del joystick izquierdo se ha presionado para pausar o reanudar el juego.
        if (Gamepad.all.Count > 0)
        {
            Gamepad gamepad = Gamepad.all[0]; // Esto asume que hay al menos un controlador conectado.

            // Comprueba si el botón "A" del joystick izquierdo ha sido presionado.
            if (gamepad.buttonSouth.wasPressedThisFrame) // "buttonSouth" es el botón "A".
            {
                TogglePausa();
            }
        }
    }

    void TogglePausa()
    {
        isPaused = !isPaused;
        pausaCanvas.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1; // Pausa el tiempo en el juego cuando esté pausado.
    }

    public void Continuar()
    {
        TogglePausa();
    }
    // Cargar el menú principal
    public void SalirAlMenuPrincipal()
    {
        SceneManager.LoadScene("StartRI"); // Reemplaza "MenuPrincipal" con el nombre de tu escena del menú principal.
    }

    // Regresar a la escena anterior
    public void RegresarAEscenaAnterior()
    {
        // Puedes almacenar el nombre de la escena anterior en una variable antes de cambiar de escena y usarla aquí.
        SceneManager.LoadScene("Bienvenido"); // Reemplaza "NombreDeLaEscenaAnterior" con el nombre de tu escena anterior.
    }



   
}

