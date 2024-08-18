using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NPCController : MonoBehaviour
{
    public string npcName;
    public bool questNPC;

    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // ���� ���� ��ȭ �ؽ�Ʈ�� ���� �迭
    //private int currentDialogueIndex = 0; // ���� ��ȭ �ε���

    private Animator animator; // Animator ������Ʈ ����

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>(); // ���̾�α� �Ŵ��� ����
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(questNPC)
        {
            OnTalkToNPC();
        }
        

        if (collision.collider.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
        }
    }

    public void OnTalkToNPC()
    {
        
        FindObjectOfType<QuestManager>().CheckQuestCompletion(SceneManager.GetActiveScene().name, npcName);
    }
}