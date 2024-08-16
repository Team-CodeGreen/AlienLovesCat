using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Quest : ScriptableObject
{
    public string questName;
    public bool isCompleted;

    public abstract void CheckQuestCompletion();

    public virtual void CompleteQuest()
    {
        
        isCompleted = true;
        Debug.Log(questName + " ¿Ï·á");

        if(QuestCanvas.Instance != null)
        {
            QuestCanvas.Instance.UpdateQuestUI();
        }

        
    }
    
}


