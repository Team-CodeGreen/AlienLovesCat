using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 씬 관리를 위해 추가

public class DialogueForInfo : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    //public Button nextButton; // 버튼 참조 추가

    private bool dialogueActive = false; // 대화 활성화 여부를 나타내는 변수

    public string[] dialogueTexts;
    private int currentDialogueIndex = 0; // 현재 대화 인덱스
    public float typingSpeed = 0.05f; // 타이핑 속도
    //public string nextSceneName = "NextScene"; // 다음 씬의 이름

    // Start is called before the first frame update
    void Start()
    {
        dialogueActive = true;
        dialogueUI.SetActive(true);
        //nextButton.onClick.AddListener(OnNextButtonClicked); // 버튼 클릭 이벤트 추가
        DisplayNextDialogue();
    }

    // Update is called once per frame
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
        
    }

    void OnNextButtonClicked() // 버튼 클릭 시 호출될 메서드 추가
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