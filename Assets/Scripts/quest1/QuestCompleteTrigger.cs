using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleteTrigger : MonoBehaviour
{
    public string questTitle;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager.instance.CompleteQuest(questTitle);
            Destroy(gameObject);  // 트리거를 한 번만 사용하도록 파괴
        }
    }
}
