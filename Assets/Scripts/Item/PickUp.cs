using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    public Item item;

    private GameObject inventory;

    [SerializeField]
    private GameObject KeyImage;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && item.available == true)
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            KeyImage.SetActive(true);
            item.available = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            KeyImage.SetActive(false);
            item.available = false;
        }
    }


}
