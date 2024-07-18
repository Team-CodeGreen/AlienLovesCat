using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // 여러 개의 대화 텍스트를 담을 배열

    
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // 다이얼로그 매니저 참조
      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // 충돌이 발생할 때 로그 출력

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueTexts); // 대화 시작
        }
    }
}