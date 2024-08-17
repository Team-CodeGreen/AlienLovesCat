using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quests/ItemQuest")]
public class ItemQuest : Quest
{
    [SerializeField]
    private Item requiredItem;

    private List<Item> items;

    private GameObject inventory;
    
    private Inventory inventoryScript;



    public override void CheckQuestCompletion()
    {
        inventory = GameObject.Find("Inventory");
        inventoryScript = inventory.GetComponent<Inventory>();

        
        if (inventoryScript != null)
        {
            Debug.Log("inventory ����");

            items = inventoryScript.GetItems();

            
            Debug.Log(items[0].name);
            Debug.Log(requiredItem);

            if (items != null && inventoryScript.HasItem(requiredItem))
            {
                Debug.Log("quest �Ϸ�");
                CompleteQuest();
            }

        }else
        {
            Debug.Log("inventory ����");
        }
        
    }
}