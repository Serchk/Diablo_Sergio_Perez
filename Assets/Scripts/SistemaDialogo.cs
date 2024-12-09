using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATR�N SINGLETONE
       //1. S�lo existe una �nica instancia de SistemaDialogo.
       //2. Es accesible desde cualquier punto del programa.

    public static SistemaDialogo sistema;

    
    // Start is called before the first frame update
    void Awake()
    {
        //Si el trono est� libre...
        if (sistema == null)
        {
            //Me hago con el trono, y entonces SistemaDialogo SOY YO (this).
            sistema = this;
        }
        else
        {
            //Me he quedao sin el trono asi que me mato.   
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogaSO dialogo)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
