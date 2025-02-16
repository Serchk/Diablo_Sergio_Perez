using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSo> OnNuevaMision;
    public void NuevaMision(MisionSo mision)
    {
        OnNuevaMision?.Invoke(mision);
    }
}
