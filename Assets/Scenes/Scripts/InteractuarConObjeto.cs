using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InteractuarConObjeto : MonoBehaviour
{
    public GameObject panelCanvas;
    private bool entornoDetenido = false;
    public InputActionProperty actionProperty;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !entornoDetenido)
        {
            // Raycast desde la posición de la cámara
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            // Verificar si el rayo intersecta con un objeto interactuable
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("ObjetoInteractuable"))
                {
                    // Activar el panel del canvas
                    panelCanvas.SetActive(true);

                    // Detener el resto del entorno
                    Time.timeScale = 0f;

                    // Indicar que el entorno está detenido
                    entornoDetenido = true;
                }
            }
        }

    }

    // Método para cambiar de escena
    public void CambiarDeEscena()
    {
        // Reanudar el entorno antes de cambiar de escena
        ReanudarEntorno();

        // Cambiar de escena
        SceneManager.LoadScene(nombreEscenaACambiar);
    }

    // Método para reanudar el entorno
    public void ReanudarEntorno()
    {
        // Desactivar el panel del canvas
        panelCanvas.SetActive(false);

        // Reanudar el tiempo
        Time.timeScale = 1f;

        // Indicar que el entorno ya no está detenido
        entornoDetenido = false;
    }

        private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            CambiarDeEscena();
        }
    }
}
