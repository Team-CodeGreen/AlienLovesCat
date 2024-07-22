using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject inventory;

    private bool active;
    
    void Start()
    {
        active = false;
        inventory = GameObject.Find("Total");
        inventory.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            active = !active;
            inventory.SetActive(active);
        }

        
    }    
    
}
