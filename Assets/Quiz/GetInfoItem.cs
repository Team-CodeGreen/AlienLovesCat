using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GetInfoItem : MonoBehaviour
{

    private GameObject inventory;

    public GameObject Panel;

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
        inventory.GetComponent<Inventory>().AddItem(info);
        Panel.SetActive(false);
    }
}
