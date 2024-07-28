using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;

    void Update()
    {
        questText.text = "";
        foreach (Quest quest in QuestManager.instance.GetAllQuests())
        {
            questText.text += quest.title + ": " + (quest.isCompleted ? "Completed" : "Incomplete") + "\n";
        }
    }
}
