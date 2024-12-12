using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Volocity", agent.velocity.magnitude / agent.speed);
    }
}
