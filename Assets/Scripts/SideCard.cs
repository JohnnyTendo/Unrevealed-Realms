using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideCard : MonoBehaviour
{
    public GameObject go;
    public Button[] buttons;
    public Slider[] slider;
    public Dropdown[] dropdowns;

    public bool ValueToBoolean(float _value)
    {
        if(_value >= 0.1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
