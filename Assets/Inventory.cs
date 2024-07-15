using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int TOTALMAX = 18;
    public int MINIMAX = 7;
    public List<SlotData> slots = new List<SlotData>();

    private void Start()
    {
        GameObject slotTotal = GameObject.Find("TotalInventory");
        GameObject slotMini = GameObject.Find("MiniInventory");

        
        
        

        for(int i = 0; i < TOTALMAX; i++)
        {
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = slotTotal.transform.GetChild(i).gameObject;
            //Debug.Log(slotTotal.transform.GetChild(i).gameObject.name);
        }

        for (int i = 0; i < MINIMAX; i++)
        {
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = slotMini.transform.GetChild(i).gameObject;
            //Debug.Log(slotMini.transform.GetChild(i).gameObject.name);
        }

    }
}
