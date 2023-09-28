using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrancisionEscena : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AnimationClip animacionfinal;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void loadScene()
    {
        StartCoroutine(CambiarEscena());
        SceneManager.LoadScene(3);
    
    }

    IEnumerator CambiarEscena(){

        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animacionfinal.length);
    }

}
