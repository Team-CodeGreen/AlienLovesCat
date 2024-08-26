using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bubblecatManager : MonoBehaviour
{
    private GameObject inventory;
    public DialogueManager dialogueManager;
    public string[] dialogueTexts; // ���� ���� ��ȭ �ؽ�Ʈ�� ���� �迭
    //private int currentDialogueIndex = 0; // ���� ��ȭ �ε���
    public Item bubblecat; //ȹ���� ������
    public GameObject ItemObject; //ȹ���� �����۰� ����� ���� ������Ʈ
    private bool check=false;

    private Animator animator; // Animator ������Ʈ ����

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        dialogueManager = FindObjectOfType<DialogueManager>(); // ���̾�α� �Ŵ��� ����
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (check == false)
            {
                dialogueManager.StartDialogue(dialogueTexts); // ��ȭ ����
                inventory.GetComponent<Inventory>().AddItem(bubblecat);
                check = true;
                if (ItemObject.CompareTag("Item"))
                {
                    Destroy(ItemObject);
                }
            }

        }
    }
}
