using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    
    private List <Transform> listadoPuntos = new List <Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform puntoRuta in ruta.transform)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
