using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    
    void Start()
    {
        
    }

    public void CheckAllQuests()
    {
        foreach (Quest quest in quests)
        {
            quest.CheckQuestCompletion();
        }
    }
}
