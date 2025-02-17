using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractuable
{
    private Outline outline;
    [SerializeField] private Texture2D iconoInteracción;
    [SerializeField] private Texture2D iconoPorDefecto;

    [SerializeField] GameObject chestClosed;
    [SerializeField] GameObject chestOpen;
    // Start is called before the first frame update
    void Start()
    {
        chestClosed.SetActive(true);
        chestOpen.SetActive(false);
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(iconoInteracción,Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(iconoPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }

    public void Interactuar(Transform interactuador)
    {
        chestClosed.SetActive(false);
        chestOpen.SetActive(true);

    }
}
