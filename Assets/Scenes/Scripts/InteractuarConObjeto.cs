using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InteractuarConObjeto : MonoBehaviour
{
    public GameObject panelCanvas;
    public AudioClip sonido; // Agrega una variable para el sonido
    private bool entornoDetenido = false;
    private bool isPaused = false;
    private Transform playerCamera;
    public InputActionProperty actionProperty;
    private float distanciaDeseada = 2.0f;
    public string nombreEscenaACambiar = "NombreDeTuEscena";

    private AudioSource audioSource; // Referencia al componente AudioSource

    private void Awake()
    {
        actionProperty.action.performed += OnButtonPressed;
        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource
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
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        
    }

    public void CambiarDeEscena()
    {
        SceneManager.LoadScene(nombreEscenaACambiar);
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            TogglePausa();
            ReproducirSonido(); // Llama a la función para reproducir el sonido
        }
    }

    void TogglePausa()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            panelCanvas.transform.position = playerCamera.position + playerCamera.forward * distanciaDeseada;
            panelCanvas.transform.rotation = playerCamera.rotation;
            panelCanvas.SetActive(true);
        }
    }

    // Función para reproducir el sonido
    void ReproducirSonido()
    {
        if (sonido != null && audioSource != null)
        {
            audioSource.clip = sonido; // Asigna el clip de sonido al AudioSource
            audioSource.Play(); // Reproduce el sonido
        }
    }
}
