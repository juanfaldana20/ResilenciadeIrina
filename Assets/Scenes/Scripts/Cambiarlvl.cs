using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Cambiarlvl : MonoBehaviour
{

public void loadScene(String sceneName)
{
    Debug.Log("Cambiando a la escena: " + sceneName);
    SceneManager.LoadScene(sceneName);
}
    
}
