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

    private bool dialogueActive = false; // 대화 활성화 여부를 나타내는 변수
    private string[] dialogueTexts; // 대화 텍스트 배열
    private int currentDialogueIndex = 0; // 현재 대화 인덱스

    void Start()
    {
        dialogueUI.SetActive(false); // 시작 시 다이얼로그 UI 비활성화
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return)))
        {
            DisplayNextDialogue(); // 다음 대화로 넘어가는 함수 호출
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueActive = true; // 대화 활성화 상태로 변경
        dialogueTexts = dialogues; // 대화 텍스트 배열 설정
        dialogueUI.SetActive(true); // 다이얼로그 UI 활성화
        dialogueText.text = dialogueTexts[currentDialogueIndex]; // 첫 번째 대화 설정

        // 플레이어 컨트롤러의 움직임 제한
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(false);
        }
    }

    void DisplayNextDialogue()
    {
        currentDialogueIndex++; // 다음 대화 인덱스로 이동
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            dialogueText.text = dialogueTexts[currentDialogueIndex]; // 다음 대화 설정
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
}