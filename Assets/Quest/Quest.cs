using System.Collections;
using System.Collections.Generic;
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

    public Item targetItem;
    public string targetNPC;
    public string targetScene;

    public Quest nextQuest;

    public List<Item> rewardItem;

    public void Initialize(string name, QuestType type, Item targetItem = null, string targetNPC = null, string targetScene = null, Quest nextQuest = null)
    {
        questName = name;
        questType = type;
        this.targetItem = targetItem;
        this.targetNPC = targetNPC;
        this.targetScene = targetScene;
        isCompleted = false;
        this.nextQuest = nextQuest;
    }

    public void CheckCompletion(Inventory inventory, string currentScene, string npcName = null)
    {
        switch(questType)
        {
            case QuestType.ItemCollection:
                if (inventory.HasItem(targetItem))
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
