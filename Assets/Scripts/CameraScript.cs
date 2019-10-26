using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject target;

    public void ToggleCamera(GameObject _target)
    {
        target = _target;
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void Update()
    {
        if (!target) { Debug.Log("No target for " + gameObject.name); return; }
        gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
    }
}
