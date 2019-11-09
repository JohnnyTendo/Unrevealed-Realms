using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject go;
    public int value;
    public int x;

    private void Awake()
    {
        go = gameObject;
    }
}
