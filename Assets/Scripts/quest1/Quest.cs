using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool isCompleted;

    public void Initialize(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isCompleted = false;
    }

    public void Complete()
    {
        isCompleted = true;
    }
}