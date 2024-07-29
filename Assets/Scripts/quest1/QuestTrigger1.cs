using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger1 : MonoBehaviour
{
    public string questTitle;
    public string questDescription;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager.instance.AddQuest(questTitle, questDescription);
            Destroy(gameObject);  // Ʈ���Ÿ� �� ���� ����ϵ��� �ı�
        }
    }
}
