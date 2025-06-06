using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startDialogue : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public Button nextButton; // 버튼 참조 추가

    private bool dialogueActive = false; // 대화 활성화 여부를 나타내는 변수
    public string[] dialogueTexts = {
        "...",
        "이건 말도 안 돼.",
        "난 지구의 멸망을 막아야만 해.",
        "왜냐하면...",
        "왜냐하면...",
        "고양이를 구해야 하니까.",
        "당장 떠날 준비를 해야겠어."
    }; // 대화 텍스트 배열
    private int currentDialogueIndex = 0; // 현재 대화 인덱스
    public float typingSpeed = 0.05f; // 타이핑 속도

    private bool isTyping = false;

    public GameObject panel;

    void Start()
    {
        dialogueActive = true;
        dialogueUI.SetActive(true);
        nextButton.onClick.AddListener(OnNextButtonClicked); // 버튼 클릭 이벤트 추가
        DisplayNextDialogue();

        // 플레이어 움직임 제한
        SetPlayerMovement(false);
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
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

        // 플레이어 움직임 제한
        SetPlayerMovement(false);
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

        if(panel != null)
        {
            panel.SetActive(false);
        }
        // 플레이어 움직임 다시 활성화
        SetPlayerMovement(true);
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

    void SetPlayerMovement(bool enable)
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(enable);
        }
    }
}
