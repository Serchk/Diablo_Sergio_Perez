using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    private Transform target;
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public Transform Target { get => target; set => target = value; }

    public void ActivarCombate(Transform target)
    {
        Debug.Log("asssssssssssssss");
        patrulla.enabled = false;
        combate.enabled = true;
        this.target = target;
    }

    public void ActivarPatrulla()
    {
        combate.enabled = false;
        patrulla.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        patrulla.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
