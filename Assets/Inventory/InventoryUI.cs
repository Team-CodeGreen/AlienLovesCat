using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour  //Canvas에 포함되는 Component
{
    public GameObject totalInventoryPanel;  //인벤토리 전체보기 UI
    bool activeTotalInventory = false;  

    private void Start()
    {
        totalInventoryPanel.SetActive(activeTotalInventory); //비활성화로 시작
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))  //I키가 눌렸을 경우 상태 전환
        {
            activeTotalInventory = !activeTotalInventory;
            totalInventoryPanel.SetActive(activeTotalInventory);
        }
    }


}
