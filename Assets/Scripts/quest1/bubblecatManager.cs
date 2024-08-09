using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblecatManager : MonoBehaviour
{
    private GameObject inventory;
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // 여러 개의 대화 텍스트를 담을 배열
    //private int currentDialogueIndex = 0; // 현재 대화 인덱스
    public Item bubblecat; //획득할 아이템
    private bool check=false;

    private Animator animator; // Animator 컴포넌트 참조

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        dialogueManager = FindObjectOfType<DialogueManager>(); // 다이얼로그 매니저 참조
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (check == false)
            {
                dialogueManager.StartDialogue(dialogueTexts); // 대화 시작
                inventory.GetComponent<Inventory>().AddItem(bubblecat);
                check = true;
            }
        }
    }
}
