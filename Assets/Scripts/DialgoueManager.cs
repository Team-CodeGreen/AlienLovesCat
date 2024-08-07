using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;  // TMP를 사용하기 위해 추가

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public Button nextButton; // 버튼 참조 추가

    private bool dialogueActive = false; // 대화 활성화 여부를 나타내는 변수
    private string[] dialogueTexts; // 대화 텍스트 배열
    private int currentDialogueIndex = 0; // 현재 대화 인덱스
    public float typingSpeed = 0.05f; // 타이핑 속도

    private bool isTyping = false;

    void Start()
    {
        dialogueUI.SetActive(false); // 시작 시 다이얼로그 UI 비활성화
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            OnNextButtonClicked(); // 엔터 키와 스페이스바를 눌렀을 때 OnNextButtonClicked 호출
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueActive = true; // 대화 활성화 상태로 변경
        dialogueTexts = dialogues; // 대화 텍스트 배열 설정
        dialogueUI.SetActive(true); // 다이얼로그 UI 활성화
        currentDialogueIndex = 0; // 대화 인덱스 초기화
        StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // 첫 번째 대화 설정

        // 플레이어 컨트롤러의 움직임 제한
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(false);
        }
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // 다음 대화 설정
        }
        else
        {
            EndDialogue(); // 대화 종료 함수 호출
        }
    }

    void EndDialogue()
    {
        dialogueActive = false; // 대화 비활성화 상태로 변경
        dialogueUI.SetActive(false); // 다이얼로그 UI 비활성화
        Debug.Log("모든 대화가 끝났습니다.");
        currentDialogueIndex = 0; // 대화 인덱스 초기화

        // 플레이어 컨트롤러의 움직임 제한 해제
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(true);
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
    }

    void OnNextButtonClicked() // 버튼 클릭 시 호출될 메서드 추가
    {
        if (dialogueActive)
        {
            if (!isTyping)
            {
                currentDialogueIndex++; // 현재 인덱스를 여기서 증가시키도록 이동
                DisplayNextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
                currentDialogueIndex++; // 현재 인덱스를 여기서 증가시키도록 이동
            }
        }
    }
}