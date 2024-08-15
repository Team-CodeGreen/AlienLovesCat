using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public bool isCompleted;

    public abstract void CheckQuestCompletion();

    public virtual void CompleteQuest()
    {
        isCompleted = true;
        Debug.Log(questName + " ¿Ï·á");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
