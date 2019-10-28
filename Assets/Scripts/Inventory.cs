using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    public Canvas inventoryUi;
    
    //New
    Item[] items;
    //EndNew

    public void SetUp()
    {
        GameObject holder = Instantiate(prefab);
        inventoryUi = holder.GetComponent<Canvas>();
        items = new Item[10]();
    }
    
    public Item GetItem(int _index)
    {
        return items[_index];
    }
    public string SetItem(Item _item)
    {
        for(int i = 0; i <= items.length; i++)
        {
            if (items[i] == null)
            {
                items[i] = _item;
                string response = _item.name + " has been added in slot " + i;
            }
        }
    }
}
