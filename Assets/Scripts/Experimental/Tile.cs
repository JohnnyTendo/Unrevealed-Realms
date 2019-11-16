using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject go;
    public GameObject[] environment;
    public int value;
    public int x;

    private void Awake()
    {
        go = gameObject;
    }

    public void Activate()
    {
        go.transform.position = new Vector2(x, -10);
        GameObject _top = Instantiate(environment[value]);
    }
}
