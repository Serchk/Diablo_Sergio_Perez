using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Misi�n")]
public class MisionSo : ScriptableObject
{
    public string ordenInicial; //mensaje inicial
    public string ordenFinal; //mensaje victoria
    public bool tieneRepeticion; //(0/15)
    public int totalRepeticiones;
    public int indiceMision;

    public int repeticionActual;
}
