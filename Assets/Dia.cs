using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dia : MonoBehaviour
{
    public DiaType diaType;
    public enum DiaType{
        RED,
        GREEN,
        BLUE
    }

    public DiaType GetDiaType(){
        return diaType;
    }
}
