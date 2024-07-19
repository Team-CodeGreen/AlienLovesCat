using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MiniInventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Slot[] miniSlots;


    private void OnValidate()
    {
        miniSlots = gameObject.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        FreshSlot();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            
            miniSlots[0].GetComponent<Image>().color = Color.red;
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


    public void UploadItem()
    {
        ///image.color = Color.red;
    }

    public void UploadItem(Item _item)
    {
        if (items.Count < miniSlots.Length)
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
}
