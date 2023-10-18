using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Supervisor : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public server servidor;

    public void Ingresarsupervisor(){
        string[] datos = new string[1];
        datos[0]= resolutionDropdown.captionText.text;
        StartCoroutine(servidor.ConsumirServicio("supervisor", datos));

    }

}
