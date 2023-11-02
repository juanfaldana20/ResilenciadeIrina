using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMang : MonoBehaviour
{
    public ProgressBarSlider progressBarSlider; // Asegúrate de asignar el SliderController en el Inspector
    public float progressPerLevel = 0.33f; // Ajusta este valor según tus necesidades

    public void LoadNextScene()
    {
        // Incrementa el progreso y actualiza el Slider
        progressBarSlider.UpdateProgressBar(progressBarSlider.progressBarSlider.value + progressPerLevel);


        // Obtén el índice de la escena actual en el orden definido en Build Settings
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carga la siguiente escena en la secuencia definida en Build Settings
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Si ya estás en la última escena, aquí puedes implementar algún comportamiento adicional, como mostrar un mensaje de "Fin del juego".
        }
    }
}
