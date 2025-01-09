using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    //definir velocidad de combate
    //poner esa velocidad al agent

    [SerializeField] private Enemigo main;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float velocidadCombate;
    private void Awake()
    {
        main.Combate = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(main.Target.position);
    }
}
