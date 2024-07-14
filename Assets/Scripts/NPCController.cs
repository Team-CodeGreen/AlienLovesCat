using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // ���� ���� ��ȭ �ؽ�Ʈ�� ���� �迭

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // ���̾�α� �Ŵ��� ����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹 �� ���̾�α� Ʈ����
            dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
        }
    }
}