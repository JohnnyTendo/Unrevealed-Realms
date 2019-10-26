using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    public Canvas inventoryUi;

    public void SetUp()
    {
        GameObject holder = Instantiate(prefab);
        inventoryUi = holder.GetComponent<Canvas>();
    }
}
