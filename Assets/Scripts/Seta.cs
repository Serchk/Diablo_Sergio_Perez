using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Seta : MonoBehaviour, IInteractuable
{
    private Outline outline;

    [SerializeField] private MisionSo mision;
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private Texture2D iconoInteracción;
    [SerializeField] private Texture2D iconoPorDefecto;
    // Start is called before the first frame update
    private void Awake()    
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void Interactuar(Transform interactor)
    {
        mision.repeticionActual++;
        Debug.Log("Sumando...");
        if (mision.repeticionActual < mision.totalRepeticiones)
        {
            Debug.Log("Actualizando...");
            eventManager.ActualizarMision(mision);
        }
        else 
        {
            Debug.Log("fin mision...");
            eventManager.TerminarMision(mision);
        }
        Destroy(gameObject);
    }
}
