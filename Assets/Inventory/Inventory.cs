using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Slot[] slots;

    private int currentPage = 0;
    private const int slotsPerPage = 7;
    private Slot focusedSlot = null;

    [SerializeField]
    private ItemQuest itemQuest;
   

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        FreshSlot();
    }

    private void Start()
    {
        UpdateSlots();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ChangePage();
        }

        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetFocus(0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetFocus(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetFocus(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetFocus(3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetFocus(4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetFocus(5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetFocus(6);
        }
    }

    private void ChangePage()
    {
        currentPage = (currentPage + 1) % (slots.Length / slotsPerPage);
        UpdateSlots();
    }

    private void UpdateSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }

        for (int i = currentPage * slotsPerPage; i < (currentPage + 1) * slotsPerPage; i++)
        {
            if(i<slots.Length)
            {
                slots[i].gameObject.SetActive(true);
            }
        }
    }

    public void FreshSlot()
    {
        if(slots == null)
        {
            return;
        }

        int i = 0;

        for(; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
            
        }

        for(; i < slots.Length; i++)
        {
            slots[i].item = null;
            
        }

    }

    private void SetFocus(int slotIndex)
    {
        int index = currentPage * slotsPerPage + slotIndex;
        if(index >= 0 && index < slots.Length)
        {
            if(focusedSlot != null)
            {
                focusedSlot.GetComponent<Image>().color = Color.white;
                focusedSlot.GetComponent<Slot>().item.usable = false;
            }

            focusedSlot = slots[index];
            focusedSlot.GetComponent<Image>().color = (Color.red);
            focusedSlot.GetComponent<Slot>().item.usable = true;
        }
    }

    public void AddItem(Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
            Debug.Log("아이템 넣음!");
        }

        
        if(itemQuest != null)
        {
            itemQuest.CheckQuestCompletion();
        }else
        {
            Debug.Log("itemQuest 없음");
        }
        
        
    }
    
    public void UseItem(Item _item)
    {
        items.Remove(_item);
        FreshSlot();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public bool HasItem(Item _item)
    {
        foreach (Item i in items)
        {
            if (i == _item)
            {
                return true;
            }
        }

        return false;
    }

}
