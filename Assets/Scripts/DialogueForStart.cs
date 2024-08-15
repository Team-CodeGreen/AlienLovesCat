using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 씬 관리를 위해 추가

public class DialogueForStart : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public Button nextButton;

    private bool dialogueActive = false;
    public string[] dialogueTexts = {
        "...",
        "이건 말도 안 돼.",
        "난 지구의 멸망을 막아야만 해.",
        "왜냐하면...",
        "왜냐하면...",
        "고양이를 구해야 하니까.",
        "당장 떠날 준비를 해야겠어."
    };
    private int currentDialogueIndex = 0;
    public float typingSpeed = 0.05f;
    public string nextSceneName = "NextScene";

    //public Quest newQuest; // 추가할 퀘스트 에셋

    void Start()
    {
        dialogueActive = true;
        dialogueUI.SetActive(true);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        DisplayNextDialogue();
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                DisplayNextDialogue();
            }
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueTexts = dialogues;
        currentDialogueIndex = 0;
        dialogueText.text = string.Empty;
        dialogueActive = true;
        dialogueUI.SetActive(true);
        DisplayNextDialogue();
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex]));
        }
        else
        {
            EndDialogue();
        }
    }

    private bool isTyping = false;

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        currentDialogueIndex++;
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        Debug.Log("모든 대화가 끝났습니다.");
        currentDialogueIndex = 0;

        /*if (QuestManager.instance != null && newQuest != null)
        {
            QuestManager.instance.AddQuest(newQuest.title, newQuest.description);
        }
        else
        {
            Debug.LogError("QuestManager 인스턴스를 찾을 수 없거나 newQuest가 설정되지 않았습니다!");
        }*/

        SceneManager.LoadScene(nextSceneName);
    }

    void OnNextButtonClicked()
    {
        if (dialogueActive)
        {
            if (!isTyping)
            {
                DisplayNextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
            }
        }
    }
}