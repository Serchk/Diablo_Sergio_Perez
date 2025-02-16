using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta1 : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void MedioAbrir()
    {
        anim.SetTrigger("MedioAbrir");
        //anim.SetBool("Plantado", true);
    }

    internal void Abrir()
    {
        anim.SetTrigger("Abrir");
    }
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
}
