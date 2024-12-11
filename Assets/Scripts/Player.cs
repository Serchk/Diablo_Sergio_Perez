using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private Transform  ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movimiento();
            ComprobarInteraccon();
        }
        
    }


    private void Movimiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                agent.SetDestination(hitInfo.point);

                ultimoClick = hitInfo.transform;
            }
        }
    }
    private void ComprobarInteraccon()
    {
        if (ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = 2;

            if(!agent.pathPending && agent.remainingDistance <agent.stoppingDistance)
            {
                npc.Interactuar(transform);

                ultimoClick = null;
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0;
        }
    }
}
