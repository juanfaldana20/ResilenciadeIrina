using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Verificacion1 : MonoBehaviour
{
    public Dropdown dropdown1;


    public void loadScene(string sceneName)
    {
        // Verifica si los tres Dropdowns tienen opciones seleccionadas
        if (ValidarDropdowns())
        {
            Debug.Log("Cambiando a la escena: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Por favor, selecciona opciones en todos los Dropdowns antes de continuar.");
            // Puedes mostrar un mensaje al usuario indicando que debe seleccionar opciones en todos los Dropdowns.
        }
    }

    private bool ValidarDropdowns()
    {
        // Verifica si todos los Dropdowns tienen opciones seleccionadas diferentes de "Seleccionar"
        return !EsOpcionDefault(dropdown1);
    }

    private bool EsOpcionDefault(Dropdown dropdown)
    {
        // Verifica si la opción seleccionada es la predeterminada ("Seleccionar")
        return dropdown.options[dropdown.value].text == "Seleccionar";
    }
}