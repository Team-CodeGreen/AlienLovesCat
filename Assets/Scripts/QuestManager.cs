using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    void Start()
    {
        //����Ʈ �߰�
        AddQuest(new Quest(1, "������ ì�⼼��.", "�濡�� �ʿ��� ��ǰ�� ì�⼼��."));
        AddQuest(new Quest(2, "�ι�° ����Ʈ", "��ȥ�� ������ ���"));
    }

    public void AddQuest(Quest quest) //����Ʈ �߰�
    {
        quests.Add(quest);
    }

    public void CompleteQuest(int questId) //����Ʈ �Ϸ�
    {
        Quest quest = quests.Find(q => q.id == questId);
        if (quest != null)
        {
            quest.isCompleted = true;
            Debug.Log("����Ʈ �Ϸ�: " + quest.title);
        }
    }

    public List<Quest> GetActiveQuests()
    {
        return quests.FindAll(q => !q.isCompleted);
    }
}
