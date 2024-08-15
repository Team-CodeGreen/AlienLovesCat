using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuest : Quest
{
    public Item requiredItem;
    private List<Item> items;
    private Inventory inventory;
    
    void Start()
    {
        
        //items = inventory.items;
    }

    public override void CheckQuestCompletion()
    {
        items = inventory.GetItems();
        Debug.Log("check");
        if (items != null && inventory.HasItem(requiredItem))
        {
            Debug.Log("hasitem");
            CompleteQuest();
        }
    }
}
