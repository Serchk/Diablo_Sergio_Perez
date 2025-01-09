using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float velocidadPatrulla;
    
    private List <Vector3> listadoPuntos = new List <Vector3>();

    private int indiceDestinoActual = -1;

    private Vector3 destinoActual;
    private void Awake()
    {
        main.Patrulla = this;
        
        foreach (Transform puntoRuta in ruta.transform)
        {
            listadoPuntos.Add(puntoRuta.position);
        }
    }
    void Start()
    {
        StartCoroutine(PatrullarYEsperar());
    }
    private void OnEnable()
    {
        agent.speed = velocidadPatrulla;
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            ClacularDestino();
            agent.SetDestination(destinoActual);
            yield return new WaitUntil( () => agent.remainingDistance <=0);//expresión lambda.

            yield return new WaitForSeconds(Random.Range(5f, 6f));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            main.ActivarCombate(other.transform);
        }
    }
}
