using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MiniInventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Slot[] miniSlots;

    private List<GameObject> inventorySlots = new List<GameObject>();



    private void OnValidate()
    {
        miniSlots = gameObject.GetComponentsInChildren<Slot>();

        for (int i = 0; i < 7; i++)
        {
            inventorySlots.Add(transform.GetChild(i).gameObject);
        }
        
    }

    void Awake()
    {
        FreshSlot();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            choiceItem(0, miniSlots[0].gameObject);
            //Debug.Log(gameObject.GetComponents<Slot>().Length);
            //gameObject.GetComponent<Image>().color = Color.red;
            //miniSlots[0].GetComponentInParent<Image>().color = Color.red;
            //transform.GetChild(0).GetComponent<Image>().color = Color.red;
            //inventorySlots[0].GetComponent<Image>().color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //inventorySlots[1].GetComponent<Image>().color = Color.red;
            choiceItem(1, miniSlots[1].gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            choiceItem(2, miniSlots[2].gameObject);
        }
        else if( Input.GetKeyDown(KeyCode.Keypad4))
        {
            choiceItem(3, miniSlots[3].gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            choiceItem(4, miniSlots[4].gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            choiceItem(5, miniSlots[5].gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            choiceItem(6, miniSlots[6].gameObject);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X");
            for(int i = 0; i < 7; i++)
            {
                
                if (inventorySlots[i].GetComponent<Image>().color == Color.red)
                {
                    UseItem(i);
                    break;
                }
                else
                {
                    continue;
                }
            }
            
        }
    }

    private void choiceItem(int num, GameObject item)
    {
        for (int i = 0; i < 7; i++)
        {
            if(i == num)
            {
                inventorySlots[i].GetComponent<Image>().color = Color.red;
                Debug.Log(item.name);
            }
            else
            {
                inventorySlots[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void FreshSlot()
    {
        if (miniSlots == null)
        {
            Debug.Log("null");
            return;
        }

        int i = 0;
        for (; i < items.Count && i < miniSlots.Length; i++)
        {
            miniSlots[i].item = items[i];
        }

        for (; i < miniSlots.Length; i++)
        {
            miniSlots[i].item = null;
        }
    }



    public void UploadItem(Item _item)
    {
        if (items.Count < miniSlots.Length && _item.itemUpload == false)
        {
            _item.itemUpload = !_item.itemUpload;
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("mini ½½·Ô ²Ë Âü");
        }
    }

    public void UseItem(int index)
    {
        Item a = items[index];
        items.Remove(items[index]);
        FreshSlot();
        GameObject.Find("Inventory").GetComponent<Inventory>().RemoveItem(a);

        
    }

    
}
