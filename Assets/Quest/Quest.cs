using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum QuestType
{
    ItemCollection,
    TalkToNPC,
    ReachLocation
}

[CreateAssetMenu(fileName = "NewQuest")]
public class Quest : ScriptableObject
{
    public string questName;
    public QuestType questType;
    public bool isCompleted;

    public List<Item> targetItems;
    public string targetNPC;
    public string targetScene;

    public Quest nextQuest;

    public bool keyQuest;

    public List<Item> rewardItem;

    public void Initialize(string name, QuestType type, List<Item> targetItems = null, string targetNPC = null, string targetScene = null, Quest nextQuest = null)
    {
        questName = name;
        questType = type;
        this.targetItems = targetItems;
        this.targetNPC = targetNPC;
        this.targetScene = targetScene;
        isCompleted = false;
        this.nextQuest = nextQuest;
        keyQuest = false;


    }

    public void CheckCompletion(Inventory inventory, string currentScene, string npcName = null)
    {
        switch(questType)
        {
            case QuestType.ItemCollection:
                var count = targetItems.Count;

                foreach(Item item in targetItems)
                {
                    if (inventory.HasItem(item))
                    {
                        count -= 1;
                    }   
                }
                if (count == 0)
                    isCompleted = true;
                break;
            case QuestType.TalkToNPC:
                if (npcName == targetNPC)
                    isCompleted = true;
                break;
            case QuestType.ReachLocation:
                if (currentScene == targetScene)
                    isCompleted = true;
                break;
        }
    }

    //¹Ì»ç¿ë
    public void GiveReward(Inventory inventory)
    {
        if (rewardItem != null)
        {
            foreach(Item item in rewardItem)
            {
                inventory.AddItem(item);
            }
            
        }
    }
}
