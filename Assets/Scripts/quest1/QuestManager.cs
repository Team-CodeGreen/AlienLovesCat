using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<Quest> quests = new List<Quest>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddQuest(string title, string description)
    {
        Quest newQuest = ScriptableObject.CreateInstance<Quest>();
        newQuest.Initialize(title, description);
        quests.Add(newQuest);
        UpdateQuestUI();
    }
    public void CollectItem(Item item)
    {
        foreach (Quest quest in quests)
        {
            if (!quest.isCompleted)
            {
                quest.CollectItem(item);
                if (quest.isCompleted)
                {
                    Debug.Log($"Quest '{quest.title}' completed!");
                }
            }
        }
        UpdateQuestUI();
    }
    public void CompleteQuest(string title)
    {
        Quest quest = quests.Find(q => q.title == title);
        if (quest != null)
        {
            quest.Complete();
            UpdateQuestUI();
        }
    }

    public List<Quest> GetAllQuests()
    {
        return quests;
    }

    private void UpdateQuestUI()
    {
        QuestUI questUI = FindObjectOfType<QuestUI>();
        if (questUI != null)
        {
            questUI.UpdateQuestUI();
        }
    }
}
