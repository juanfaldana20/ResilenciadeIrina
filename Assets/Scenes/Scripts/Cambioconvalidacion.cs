using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cambioconvalidacion : MonoBehaviour
{
    private Dropdown[] dropdowns;

    private void Awake()
    {
        // Busca todos los objetos con la etiqueta "Dropdown" (o la etiqueta que hayas asignado)
        GameObject[] dropdownObjects = GameObject.FindGameObjectsWithTag("Dropdown");

        // Inicializa el arreglo de Dropdowns con la longitud de los objetos encontrados
        dropdowns = new Dropdown[dropdownObjects.Length];

        // Itera a través de los objetos encontrados y busca el componente Dropdown en cada uno
        for (int i = 0; i < dropdownObjects.Length; i++)
        {
            dropdowns[i] = dropdownObjects[i].GetComponent<Dropdown>();
        }
    }

    public void loadScene(string sceneName)
    {
        // Verifica si todos los Dropdowns tienen opciones seleccionadas
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
        foreach (Dropdown dropdown in dropdowns)
        {
            if (EsOpcionDefault(dropdown))
            {
                return false;
            }
        }
        return true;
    }

    private bool EsOpcionDefault(Dropdown dropdown)
    {
        // Verifica si la opción seleccionada es la predeterminada ("Seleccionar")
        return dropdown.options[dropdown.value].text == "Seleccionar";
    }

}
