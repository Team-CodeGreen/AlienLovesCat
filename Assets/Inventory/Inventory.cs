using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;

    //[SerializeField]
    //private Transform slotParentMini;

    [SerializeField]
    private Slot[] totalSlots;

    //[SerializeField]
    //private Slot[] miniSlots;


    private void OnValidate()
    {
        totalSlots = slotParent.GetComponentsInChildren<Slot>();
        //miniSlots = slotParentMini.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        FreshSlot();
    }



    public void FreshSlot()
    {
        if(totalSlots == null/* || miniSlots == null*/)
        {
            Debug.Log("null");
            return;
        }

        int i = 0;
        for (; i < items.Count && i < totalSlots.Length; i++)
        {
            totalSlots[i].item = items[i];

            /*if(i < miniSlots.Length)
            {
                miniSlots[i].item = items[i];
            }*/
        }

        for (; i < totalSlots.Length; i++)
        {
            totalSlots[i].item = null;

            /*if (i < miniSlots.Length)
            {
                miniSlots[i].item = null;
            }*/
        }
    }

    public void AddItem(Item _item)
    {
        if(items.Count < totalSlots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("½½·Ô ²Ë Âü");
        }
    }

    public void RemoveItem(Item _item)
    {
        items.Remove(_item);
        FreshSlot();
    }

    
    
}
