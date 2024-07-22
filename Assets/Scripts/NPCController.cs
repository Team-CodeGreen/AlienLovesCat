using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // ���� ���� ��ȭ �ؽ�Ʈ�� ���� �迭
    //private int currentDialogueIndex = 0; // ���� ��ȭ �ε���

    private Animator animator; // Animator ������Ʈ ����

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // ���̾�α� �Ŵ��� ����
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
        }
    }
}