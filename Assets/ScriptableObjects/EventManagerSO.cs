using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action<MisionSo> OnNuevaMision;
    public event Action<MisionSo> OnActualizarMision;
    public event Action<MisionSo> OnTerminarMision;
    public void NuevaMision(MisionSo mision)
    {
        OnNuevaMision?.Invoke(mision);
    }
    internal void ActualizarMision(MisionSo mision)
    {
        OnActualizarMision?.Invoke(mision);
    }
    internal void TerminarMision(MisionSo mision)
    {
        OnTerminarMision?.Invoke(mision);
    }

}
