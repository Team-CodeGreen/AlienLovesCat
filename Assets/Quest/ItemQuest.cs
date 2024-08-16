using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quests/ItemQuest")]
public class ItemQuest : Quest
{
    public Item requiredItem;
    private List<Item> items;

    private GameObject inventory;
    
    private Inventory inventoryScript;



    public override void CheckQuestCompletion()
    {
        inventory = GameObject.Find("Inventory");
        inventoryScript = inventory.GetComponent<Inventory>();  


        if (inventoryScript != null)
        {
            items = inventoryScript.GetItems();

            if (items != null && inventoryScript.HasItem(requiredItem))
            {
                CompleteQuest();
            }

        }else
        {
            Debug.Log("inventory ¾øÀ½");
        }
        
    }
}