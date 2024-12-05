using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Outline outline;
    [SerializeField] private Texture2D iconoInteracción;
    [SerializeField] private Texture2D iconoPorDefecto;

    [SerializeField] private float duracionRotacion;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interactuar(Transform interactuador)
    {
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y);
        Debug.Log("Hola viajero.");
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
}
