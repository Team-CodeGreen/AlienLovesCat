using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Image image;

    private GameObject inventory;

    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    //이건 inventory.cs에 들어가야하는 거 아닐까?
    private void Start()
    {
        inventory = GameObject.Find("Mini");
    }

    

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnpointerClick");
        if(item != null)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log(item);
                inventory.GetComponent<MiniInventory>().UploadItem(item);
                
            }
        }
    }
}
