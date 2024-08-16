using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class QuestCanvas : MonoBehaviour
{
    public static QuestCanvas Instance { get; private set; }

    public GameObject questUIPrefab;
    public Transform questUIParent;
    public QuestManager questManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

            // Start is called before the first frame update
            void Start()
    {
        if(questManager == null)
        {
            Debug.Log("quest manager ¾øÀ½");
            return;
        }

        foreach(Quest quest in questManager.quests)
        {
            GameObject questUI = Instantiate(questUIPrefab, questUIParent);
            TextMeshProUGUI questNameText = questUI.transform.Find("QuestNameText").GetComponent<TextMeshProUGUI>();
            Toggle questCompleteToggle = questUI.transform.Find("QuestCompleteToggle").GetComponent<Toggle>();

            questNameText.text = quest.questName;
            questCompleteToggle.isOn = quest.isCompleted;
        }
    }

    public void UpdateQuestUI()
    {
/*        foreach(Transform child in questUIParent)
        {
            Destroy(child.gameObject);
        }
*/
        Start();
    }
}
