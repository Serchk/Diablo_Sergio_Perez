using System;
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
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        main.Combate = this;
    }
    private void OnEnable()
    {
        agent.speed = velocidadCombate;
        agent.stoppingDistance = distanciaAtaque;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(main.Target != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            EnfocarObjetivo();

            agent.SetDestination(main.Target.position);

            if(!agent.pathPending && agent.remainingDistance <= distanciaAtaque)
            {
                //agent.isStopped = true;
                anim.SetBool("Attack", true);
            }
        }
        else
        {
            enabled = false;
            main.ActivarPatrulla();
            //anim.SetBool("Attack", false);
        }
    }

    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.Target.transform.position - transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;
    }
    #region
    private void Atacar()
    {

    }
    private void FinAnimacionAtaque()
    {

    }
    #endregion

}
