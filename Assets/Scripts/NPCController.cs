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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // �浹�� �߻��� �� �α� ���

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
        }
    }
}