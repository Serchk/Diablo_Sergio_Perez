using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    //PATRÓN SINGLETONE
       //1. Sólo existe una única instancia de SistemaDialogo.
       //2. Es accesible desde cualquier punto del programa.

    public static SistemaDialogo sistema;

    [SerializeField] private GameObject marcoDialogo;

    [SerializeField] private TMP_Text textoDialogo;

    [SerializeField] private Transform npcCamera;

    private bool escribiendo;
    private int indiceFraseActual = 0;

    private DialogaSO dialogoActual;

    
    // Start is called before the first frame update
    void Awake()
    {
        //Si el trono está libre...
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

    public void IniciarDialogo(DialogaSO dialogo, Transform cameraPoint)
    {
        Time.timeScale = 0;
        dialogoActual = dialogo;
        marcoDialogo.SetActive(true);
        npcCamera.SetPositionAndRotation(cameraPoint.position, cameraPoint.rotation);
        StartCoroutine(EscribirFrase());

    }
    IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = string.Empty;
        char[] fraseEnLetras = dialogoActual.frase[indiceFraseActual].ToCharArray();

        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }
    public void CompletarFrase()
    {
        textoDialogo.text = dialogoActual.frase[indiceFraseActual];
        StopAllCoroutines();
        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if (!escribiendo)
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frase.Length)
            {
                StartCoroutine(EscribirFrase());
            }
            else
            {
                FinalizarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }
    }
    private void FinalizarDialogo()
    {
        
        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        escribiendo = false;
        dialogoActual = null;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
