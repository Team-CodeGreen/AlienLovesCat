using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public QuestManager questManager;
    public GameObject questPanel;
    public TMP_Text questText;

    void Start()
    {
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        questText.text = "";
        foreach (Quest quest in questManager.GetActiveQuests())
        {
            questText.text += quest.title + ": " + quest.description + "\n";
        }
    }
}
