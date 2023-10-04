using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausaCanvas; // Arrastra el Canvas de pausa aquí
    private bool isPaused = false;
    private Transform playerCamera; // Cámara del jugador
    private float distanciaDeseada = 2.0f; // Cambia este valor según tus necesidades

    public InputActionProperty actionProperty;

    private void Awake()
    {
        actionProperty.action.performed += OnButtonPressed;
    }

    private void OnEnable()
    {
        actionProperty.action.Enable();
    }

    private void OnDisable()
    {
        actionProperty.action.Disable();
    }

    void Start()
    {
        pausaCanvas.SetActive(false);
        playerCamera = Camera.main.transform; // Obtén la cámara principal como la cámara del jugador
    }

    void Update()
    {
        // Comprueba si la tecla "P" ha sido presionada para mostrar o ocultar el menú de pausa.
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TogglePausa();
        }
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            TogglePausa();
        }
    }

    void TogglePausa()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Coloca el Canvas frente al jugador.
            pausaCanvas.transform.position = playerCamera.position + playerCamera.forward * distanciaDeseada;
            pausaCanvas.transform.rotation = playerCamera.rotation;

            // Activa el Canvas de pausa.
            pausaCanvas.SetActive(true);

            // Bloquea el movimiento y rotación del jugador (ajusta esto según tu controlador de movimiento).
            // Ejemplo: playerController.LockMovementAndRotation();
        }
        else
        {
            // Desactiva el Canvas de pausa.
            pausaCanvas.SetActive(false);

            // Reanuda el movimiento y rotación del jugador (ajusta esto según tu controlador de movimiento).
            // Ejemplo: playerController.UnlockMovementAndRotation();
        }
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


