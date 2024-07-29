using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    public Item item;

    private GameObject inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
