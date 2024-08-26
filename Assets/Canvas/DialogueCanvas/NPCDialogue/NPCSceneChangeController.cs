using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSceneChangeController : MonoBehaviour
{
    public NPCSceneChangeDialogue dialogueManager;
    public string[] dialogueTexts; // ���� ���� ��ȭ �ؽ�Ʈ�� ���� �迭
    //private int currentDialogueIndex = 0; // ���� ��ȭ �ε���

    private Animator animator; // Animator ������Ʈ ����

    void Start()
    {
        dialogueManager = FindObjectOfType<NPCSceneChangeDialogue>(); // ���̾�α� �Ŵ��� ����
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
        }
    }
}
