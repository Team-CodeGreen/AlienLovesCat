using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{

    public GameObject questUIPrefab;  // Prefab for quest UI elements
    public Transform questListParent; // Parent transform for quest UI elements

    private List<GameObject> questUIObjects = new List<GameObject>();

    void Start()
    {
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        // Remove existing UI elements
        foreach (var questUIObject in questUIObjects)
        {
            if (questUIObject != null)
            {
                Destroy(questUIObject);
            }
        }
        questUIObjects.Clear();

        // Update UI with the current quests
        foreach (var quest in QuestManager.instance.GetAllQuests())
        {
            GameObject questUIObject = Instantiate(questUIPrefab, questListParent);
            var titleText = questUIObject.transform.Find("Title")?.GetComponent<TMP_Text>();
            var descriptionText = questUIObject.transform.Find("Description")?.GetComponent<TMP_Text>();

            if (titleText != null) titleText.text = quest.title;
            if (descriptionText != null) descriptionText.text = quest.description;

            questUIObjects.Add(questUIObject);
        }
    }
}