using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;
    
    private List <Vector3> listadoPuntos = new List <Vector3>();

    private int indiceDestinoActual =0;

    private Vector3 destinoActual;
    private void Awake()
    {
        
        foreach (Transform puntoRuta in ruta.transform)
        {
            listadoPuntos.Add(puntoRuta.position);
        }
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            ClacularDestino();
            agent.SetDestination(destinoActual);
            yield return new WaitUntil( () => agent.remainingDistance <=0);//expresión lambda.

            yield return new WaitForSeconds(5);
        }

    }

    private void ClacularDestino()
    {
        indiceDestinoActual++;
        if (indiceDestinoActual >= listadoPuntos.Count)
        {
            indiceDestinoActual = 0;
        }

        destinoActual = listadoPuntos[indiceDestinoActual];
    }
}
