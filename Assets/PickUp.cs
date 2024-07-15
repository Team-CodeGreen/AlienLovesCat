using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public GameObject slotItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                if (inventory.slots[i].isEmpty)
                {
                    Instantiate(slotItem, inventory.slots[i].slotObj.transform);
                    inventory.slots[i].isEmpty = false;
                    Destroy(gameObject);
                    break;
                }
            }
            
        }
    }
}
