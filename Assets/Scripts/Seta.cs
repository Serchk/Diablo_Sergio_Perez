using System.Collections;
using System.Collections.Generic;
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
        if(mision.repeticionActual < mision.totalRepeticiones)
        {
            eventManager.ActualizarMision(mision);
        }
        else
        {
            eventManager.TerminarMision(mision);
        }
        Destroy(gameObject);
    }
}
