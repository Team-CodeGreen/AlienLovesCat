using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool isCompleted;

    public List<Item> requiredItems; // 퀘스트 완료에 필요한 아이템 목록
    private Dictionary<Item, bool> collectedItems; // 획득한 아이템을 추적
    public void Initialize(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isCompleted = false; 
        
        //퀘스트에 필요한 아이템
        this.requiredItems = new List<Item>(requiredItems);
        collectedItems = new Dictionary<Item, bool>();

        foreach (Item item in requiredItems)
        {
            collectedItems[item] = false; // 초기 상태는 모두 미획득 상태
        }
    }

    public void Complete()
    {
        isCompleted = true;
    }

    public void CollectItem(Item item)
    {
        if (collectedItems.ContainsKey(item))
        {
            collectedItems[item] = true; // 아이템을 획득한 상태로 표시

            // 모든 아이템을 획득했는지 확인
            isCompleted = CheckCompletion();
        }
    }

    private bool CheckCompletion()
    {
        foreach (bool collected in collectedItems.Values)
        {
            if (!collected)
            {
                return false;
            }
        }
        return true;
    }
}