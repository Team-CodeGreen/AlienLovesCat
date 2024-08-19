using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests;
    public int maxActiveQuests = 3;

    public Inventory inventory;

    public Toggle[] questToggles;    

    void Start()
    {
        UpdateQuestUI();
        SceneManager.sceneLoaded += OnSceneLoaded;
        CheckQuestCompletion(SceneManager.GetActiveScene().name);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void AddQuest(Quest quest)
    {
        if(activeQuests.Count < maxActiveQuests)
        {
            
            if (!activeQuests.Contains(quest)) 
            {
                activeQuests.Add(quest);
                UpdateQuestUI();

                
                CheckQuestCompletion(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            Debug.Log("퀘스트 한도 초과");
        }
    }

    public void CheckQuestCompletion(string currentScene, string npcName = null)
    {
        
        List<Quest> questsToAdd = new List<Quest>();

        for (int i = 0; i < activeQuests.Count; i++)
        {
            var quest = activeQuests[i];
            quest.CheckCompletion(inventory, currentScene, npcName);

            if (quest.isCompleted)
            {
                foreach(Item item in quest.rewardItem)
                {
                    if(!inventory.HasItem(item))
                    {
                        inventory.AddItem(item);
                    }
                }
                

                if (quest.nextQuest != null && !activeQuests.Contains(quest.nextQuest))
                {
                    questsToAdd.Add(quest.nextQuest);
                }

                if(quest.keyQuest)
                {
                    UpdateChangeSceneTriggers();
                }
            }
        }

        foreach (var quest in questsToAdd)
        {
            AddQuest(quest);
        }


        UpdateQuestUI();
    }

    void UpdateQuestUI()
    {
        for(int i = 0; i < questToggles.Length; i++)
        {
            if(i < activeQuests.Count)
            {
                questToggles[i].gameObject.SetActive(true);
                questToggles[i].isOn = activeQuests[i].isCompleted;
                questToggles[i].GetComponentInChildren<TextMeshProUGUI>().text = activeQuests[i].questName;

                
                //questUI[i].text = activeQuests[i].questName + (activeQuests[i].isCompleted ? "(completed)" : "(in progress");
            }
            else
            {
                questToggles[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckQuestCompletion(scene.name);
    }

    private void UpdateChangeSceneTriggers()
    {
        var changeSceneObj = GameObject.FindGameObjectWithTag("NextScene");

        changeSceneObj.GetComponent<ChangeScene>().UpdateTriggerStatus(true);
    }

}
