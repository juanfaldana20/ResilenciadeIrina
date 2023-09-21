using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject PausaUI;

    private void Start()
    {
        
    }

   void Update()
    {
        // Pausar el juego con el botón del controlador Oculus Quest
        if (Input.GetButtonDown("PauseButton"))
        {
            TogglePause();
        }

        // Pausar el juego con una tecla del teclado (por ejemplo, la tecla "P")
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    // Función para pausar o reanudar el juego
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pausar el tiempo del juego
            PausaUI.SetActive(true); // Mostrar el Canvas de Pausa
        }
        else
        {
            Time.timeScale = 1; // Reanudar el tiempo del juego
            PausaUI.SetActive(false); // Ocultar el Canvas de Pausa
        }
    }

    // Agrega aquí las funciones para Continuar, Retroceder y Salir
    public void Continuar()
    {
        TogglePause();
    }

public void Retroceder()
{
    // Implementa lógica para retroceder a la escena anterior aquí
    // Por ejemplo, puedes cargar la escena anterior por nombre o índice.
}

public void Salir()
{
    // Implementa lógica para salir del juego aquí
    // Por ejemplo, puedes usar Application.Quit() si estás construyendo para PC.
}
}