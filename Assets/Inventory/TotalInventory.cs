using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TotalInventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public Transform container;
    public List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < 18; i++)
        {
            slots.Add(slotPrefab);
            Instantiate(slots[i], container);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
