using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private Texture2D iconoInteracción;
    [SerializeField] private Texture2D iconoPorDefecto;

    [SerializeField] EventManagerSO eventManager;

    [SerializeField] MisionSo miMision;

    [SerializeField] private DialogaSO miDialogo1;

    [SerializeField] private DialogaSO miDialogo2;

    [SerializeField] private float duracionRotacion;
    [SerializeField] private Transform cameraNPC;

    private DialogaSO dialogoActual;

    private void Awake()
    {
        dialogoActual = miDialogo1;

    }
    private void OnEnable()
    {
        eventManager.OnTerminarMision += CambiarDialogo;
    }

    private void CambiarDialogo(MisionSo misionTerminada)
    {
        if(miMision == misionTerminada)
        {
            Debug.Log("camnaindo dialogo");
            dialogoActual = miDialogo2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interactuar(Transform interactor)
    {
        transform.DOLookAt(interactor.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }
    private void IniciarInteraccion()
    {
        SistemaDialogo.sD.IniciarDialogo(dialogoActual, cameraNPC);
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(iconoInteracción, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(iconoPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
    private void OnDisable()
    {
        eventManager.OnTerminarMision -= CambiarDialogo;
    }

}
