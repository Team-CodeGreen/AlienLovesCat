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
        questUIPrefab.SetActive(false);  // �⺻ ���¿��� ��Ȱ��ȭ
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        Debug.Log("Updating Quest UI");

        // ���� UI ����
        foreach (var questUIObject in questUIObjects)
        {
            if (questUIObject != null)
            {
                Debug.Log("Destroying: " + questUIObject.name);
                Destroy(questUIObject);
            }
        }
        questUIObjects.Clear();

        // ������ ����Ʈ�� ������Ʈ
        foreach (var quest in QuestManager.instance.GetAllQuests())
        {
            GameObject questUIObject = Instantiate(questUIPrefab, questListParent);
            questUIObject.SetActive(true);  // �ν��Ͻ�ȭ �� Ȱ��ȭ

            var titleText = questUIObject.transform.Find("Title")?.GetComponent<TMP_Text>();
            var descriptionText = questUIObject.transform.Find("Description")?.GetComponent<TMP_Text>();

            if (titleText != null) titleText.text = quest.title;
            if (descriptionText != null) descriptionText.text = quest.description;

            Debug.Log("Instantiated Quest UI: " + quest.title);

            questUIObjects.Add(questUIObject);
        }
    }
}