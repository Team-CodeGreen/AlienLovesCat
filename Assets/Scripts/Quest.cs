using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int id;
    public string title;
    public string description;
    public bool isCompleted;

    public Quest(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.isCompleted = false;
    }
}
