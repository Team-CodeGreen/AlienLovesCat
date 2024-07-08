using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject totalInventoryPanel;
    bool activeTotalInventory = false;

    private void Start()
    {
        totalInventoryPanel.SetActive(activeTotalInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeTotalInventory = !activeTotalInventory;
            totalInventoryPanel.SetActive(activeTotalInventory);
        }
    }


}
