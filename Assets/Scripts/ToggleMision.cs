using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleMision : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textoMision;

    private ToggleMision toggleVisual;

    public TMP_Text TextoMision { get => textoMision;}
    public ToggleMision ToggleVisual { get => toggleVisual;}

    private void Awake()
    {
        toggleVisual = new ToggleMision();
    }
}
