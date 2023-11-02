using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSlider : MonoBehaviour
{
   
    private Transform playerCamera; // Cámara del jugador
    public Slider progressBarSlider;
    private float distanciaDeseada = 6.0f; // Cambia este valor según tus necesidades
    // Start is called before the first frame update
    void Start()
    {
         playerCamera = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void UpdateProgressBar(float value)
    {
        progressBarSlider.value = Mathf.Clamp01(value);
    }
}
