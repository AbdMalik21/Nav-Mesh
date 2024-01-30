using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaDoor : MonoBehaviour
{
    public Dia.DiaType diaType;

    public Dia.DiaType GetDiaType(){
        return diaType;
    }

    public void OpenDoor(){
        gameObject.SetActive(false);
    }
}
