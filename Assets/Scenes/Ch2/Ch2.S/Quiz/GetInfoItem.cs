using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GetInfoItem : MonoBehaviour
{

    private GameObject inventory;

    public GameObject panel;

    public TextMeshProUGUI text;

    public bool haveItem = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputItem(Item info)
    {
        if(haveItem)
        {
            text.text = "이미 가져간 정보입니다.";
            
        }else
        {
            if (inventory != null)
            {
                inventory.GetComponent<Inventory>().AddItem(info);
                panel.SetActive(false);
                haveItem = true;
            }
            else
            {
                Debug.Log("inventory 없음");
            }
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
