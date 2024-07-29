using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        // QuestManager �ʱ�ȭ
        if (QuestManager.instance == null)
        {
            GameObject questManager = new GameObject("QuestManager");
            questManager.AddComponent<QuestManager>();
        }
    }
}
