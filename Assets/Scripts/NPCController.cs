using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // 여러 개의 대화 텍스트를 담을 배열
    private int currentDialogueIndex = 0; // 현재 대화 인덱스

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // 다이얼로그 매니저 참조
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌 시 다이얼로그 트리거
            if (currentDialogueIndex < dialogueTexts.Length)
            {
                dialogueManager.StartDialogue(dialogueTexts[currentDialogueIndex]); // 현재 인덱스의 대화 시작
                currentDialogueIndex++; // 다음 대화로 넘어감
            }
            else
            {
                // 대화가 끝나면 원하는 동작 수행
                Debug.Log("모든 대화가 끝났습니다.");
            }
            // 다른 필요한 동작 추가 가능
        }
    }
}