using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    void Start()
    {
        //퀘스트 추가
        AddQuest(new Quest(1, "가방을 챙기세요.", "방에서 필요한 물품을 챙기세요."));
        AddQuest(new Quest(2, "두번째 퀘스트", "사혼의 구슬을 모아"));
    }

    public void AddQuest(Quest quest) //퀘스트 추가
    {
        quests.Add(quest);
    }

    public void CompleteQuest(int questId) //퀘스트 완료
    {
        Quest quest = quests.Find(q => q.id == questId);
        if (quest != null)
        {
            quest.isCompleted = true;
            Debug.Log("퀘스트 완료: " + quest.title);
        }
    }

    public List<Quest> GetActiveQuests()
    {
        return quests.FindAll(q => !q.isCompleted);
    }
}
