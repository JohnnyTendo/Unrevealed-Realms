using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    public Canvas inventoryUi;
    
    //New
    [SerializeField]
    public Dictionary<Enumerators.Slot, Item> equipment = new Dictionary<Enumerators.Slot, Item>();
    //EndNew

    //Can probably be removed
    [SerializeField]
    public List<Item> helperList;

    public void SetUp()
    {
        GameObject holder = Instantiate(prefab);
        inventoryUi = holder.GetComponent<Canvas>();
    }
    
    public Item GetEquipment(Enumerators.Slot _slot)
    {
        return equipment[_slot];
    }

    public void SetItem(Item _item)
    {
        equipment[_item.slot] = _item;
        Helper();
    }

    void Helper()
    {
        helperList.Clear();
        foreach (var slot in equipment)
        {
            helperList.Add(slot.Value);
        }
    }
}
