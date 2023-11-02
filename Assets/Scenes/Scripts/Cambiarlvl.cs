using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Cambiarlvl : MonoBehaviour
{
    public LevelMang levelManager;
    public void loadScene(String sceneName)
    {
        Debug.Log("Cambiando a la escena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    public void CompleteLevel()
    {
        // Llama a la función para cargar el siguiente nivel y actualizar el progreso
        levelManager.LoadNextScene();
    }
    
}
