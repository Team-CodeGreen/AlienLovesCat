using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GetInfoItem : MonoBehaviour
{
    [SerializeField]
    private Item info;

    private Inventory inventory;

    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputItem()
    {
        inventory.AddItem(info);
        Panel.SetActive(false);
    }
}
