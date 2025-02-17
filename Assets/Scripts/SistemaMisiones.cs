using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField]
    private EventManagerSO eventManager;

    [SerializeField]
    private ToggleMision[] togglesMision; //coleccion de togles


    private void OnEnable()
    {
        //me suscribo al evento y lo vinculo con el metodo.
        eventManager.OnNuevaMision += EncenderToggleMision;
        eventManager.OnActualizarMision += ActualizarToggleMision;
        eventManager.OnTerminarMision += TerminarToggleMision;
        //ev/*entManager.OnTerminarMision += TerminarToggleMision;*/
    }
    private void EncenderToggleMision(MisionSo mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;

        if (mision.tieneRepeticion)
        {
            togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";

        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true);
    }
   
    private void ActualizarToggleMision(MisionSo mision)
    {
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMision.text += "(" + mision.repeticionActual + "/" + mision.totalRepeticiones + ")";
    }
    private void TerminarToggleMision(MisionSo mision)
    {
        togglesMision[mision.indiceMision].ToggleVisual.isOn = true;
        togglesMision[mision.indiceMision].TextoMision.text = mision.ordenFinal;
    }



}
