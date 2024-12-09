using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Di�logo")]
public class DialogaSO : ScriptableObject
{
    [TextArea(1, 5)]
    public string[] frase;

    public float tiempoEntreLetras;
}
