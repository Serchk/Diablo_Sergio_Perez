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

    [SerializeField] GameObject canvasPausa;
    [SerializeField] GameObject canvasMapa;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CanvasPausa();
        if (Time.timeScale == 1)
        {
            Movimiento();            
        }
        ComprobarInteraccon();
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
    //private void Interacciones()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //    {
    //        Collider coll = Physics.OverlapSphere();
    //        if(coll.TryGetComponent(out IInteractuable interactuable))
    //        {
    //            interactuable.Interactuar():
    //        }
    //    }
    //}
    private void ComprobarInteraccon()
    {
        if (ultimoClick != null && ultimoClick.TryGetComponent(out NPC npc))
        {
            agent.stoppingDistance = 2;

            if(!agent.pathPending && agent.remainingDistance <agent.stoppingDistance)
            {
                npc.Interact(transform);

                ultimoClick = null;
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0;
        }
    }

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("Me hacen pupa: " + danhoAtaque);
    }
    private void CanvasPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(!canvasPausa.activeSelf);
            if (canvasPausa.activeSelf)
            {
                Time.timeScale = 0.2f;
                Cursor.lockState = CursorLockMode.None;
                canvasMapa.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                canvasMapa.SetActive(true);
            }
        }

    }
}
