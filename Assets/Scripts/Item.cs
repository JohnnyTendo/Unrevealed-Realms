
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Enumerators.Dices value;
    public Enumerators.Slot slot;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Character>().GetPlayer().inventory.SetItem(this);
            gameObject.SetActive(false);
        }
    }

    public void SetValues(Item _template)
    {
        itemName = _template.itemName;
        value = _template.value;
        slot = _template.slot;
    }
}