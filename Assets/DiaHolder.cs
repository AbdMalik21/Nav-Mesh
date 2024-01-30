using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaHolder : MonoBehaviour
{
    public event EventHandler OnDiasChanged;

    private List<Dia.DiaType> DiaList;

    void Awake(){
        DiaList = new List<Dia.DiaType>();
    }

    public List<Dia.DiaType> GetDiaList(){
        return DiaList;
    }

    public void AddDia(Dia.DiaType diaType){
        DiaList.Add(diaType);
        OnDiasChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveDia(Dia.DiaType diaType){
        DiaList.Remove(diaType);
        OnDiasChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ConstainsDia(Dia.DiaType diaType){
        return DiaList.Contains(diaType);
    }

    private void OnTriggerEnter(Collider collider){
        Dia dia = collider.GetComponent<Dia>();
        if(dia != null){
            AddDia(dia.GetDiaType());
            Destroy(dia.gameObject);
        }

        DiaDoor door = collider.GetComponent<DiaDoor>();
        if(door != null){
            if(ConstainsDia(door.GetDiaType())){
                RemoveDia(door.GetDiaType());
                door.OpenDoor();
            }
        }
    }
}
