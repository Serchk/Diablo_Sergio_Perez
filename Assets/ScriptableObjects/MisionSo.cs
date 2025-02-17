using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misión")]
public class MisionSo : ScriptableObject
{
    public string ordenInicial; //mensaje inicial
    public string ordenFinal; //mensaje victoria
    public bool tieneRepeticion; //(0/15)
    public int totalRepeticiones;
    public int indiceMision;
    [NonSerialized]
    public int repeticionActual;
}
