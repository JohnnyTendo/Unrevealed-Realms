using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFontScript : MonoBehaviour
{
    public Font inactiveFont;
    public Font activeFont;
    public GameObject label;
    Text text;

    void Start()
    {
        text = label.GetComponent<Text>();
        text.font = inactiveFont;
    }

    public void Activate()
    {
        text.font = activeFont;
    }

    public void Deactivate()
    {
        text.font = inactiveFont;
    }
}
