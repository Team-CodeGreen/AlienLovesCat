using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour  //Canvas�� ���ԵǴ� Component
{
    public GameObject totalInventoryPanel;  //�κ��丮 ��ü���� UI
    bool activeTotalInventory = false;  

    private void Start()
    {
        totalInventoryPanel.SetActive(activeTotalInventory); //��Ȱ��ȭ�� ����
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  //IŰ�� ������ ��� ���� ��ȯ
        {
            activeTotalInventory = !activeTotalInventory;
            totalInventoryPanel.SetActive(activeTotalInventory);
        }
    }


}
