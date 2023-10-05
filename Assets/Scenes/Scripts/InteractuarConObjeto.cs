using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InteractuarConObjeto : MonoBehaviour
{
    public GameObject panelCanvas;
    private bool entornoDetenido = false;
    private bool isPaused = false;
    private Transform playerCamera; // Cámara del jugador
    public InputActionProperty actionProperty;
    private float distanciaDeseada = 2.0f; // Cambia este valor según tus necesidades


    // Nombre de la escena a la que quieres cambiar
    public string nombreEscenaACambiar = "NombreDeTuEscena";

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
        playerCamera = Camera.main.transform; // Obtén la cámara principal como la cámara del jugador
    }


    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E) && !entornoDetenido)
        // {
        //     // Raycast desde la posición de la cámara
        //     Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //     RaycastHit hit;

        //     // Verificar si el rayo intersecta con un objeto interactuable
        //     if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //     {
        //         if (hit.collider.CompareTag("ObjetoInteractuable"))
        //         {
        //             // Activar el panel del canvas
        //             panelCanvas.SetActive(true);

        //             // Detener el resto del entorno
        //             Time.timeScale = 0f;

        //             // Indicar que el entorno está detenido
        //             entornoDetenido = true;
        //         }
        //     }
        // }

    }

    // Método para cambiar de escena
    public void CambiarDeEscena()
    {

        // Cambiar de escena
        SceneManager.LoadScene(nombreEscenaACambiar);
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
            panelCanvas.transform.position = playerCamera.position + playerCamera.forward * distanciaDeseada;
            panelCanvas.transform.rotation = playerCamera.rotation;

            // Activa el Canvas de pausa.
            panelCanvas.SetActive(true);

            // Bloquea el movimiento y rotación del jugador (ajusta esto según tu controlador de movimiento).
            // Ejemplo: playerController.LockMovementAndRotation();
        }
    }
}
