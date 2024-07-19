using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;  // TMP�� ����ϱ� ���� �߰�

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    private bool dialogueActive = false; // ��ȭ Ȱ��ȭ ���θ� ��Ÿ���� ����
    private string[] dialogueTexts; // ��ȭ �ؽ�Ʈ �迭
    private int currentDialogueIndex = 0; // ���� ��ȭ �ε���

    void Start()
    {
        dialogueUI.SetActive(false); // ���� �� ���̾�α� UI ��Ȱ��ȭ
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return)))
        {
            DisplayNextDialogue(); // ���� ��ȭ�� �Ѿ�� �Լ� ȣ��
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueActive = true; // ��ȭ Ȱ��ȭ ���·� ����
        dialogueTexts = dialogues; // ��ȭ �ؽ�Ʈ �迭 ����
        dialogueUI.SetActive(true); // ���̾�α� UI Ȱ��ȭ
        dialogueText.text = dialogueTexts[currentDialogueIndex]; // ù ��° ��ȭ ����

        // �÷��̾� ��Ʈ�ѷ��� ������ ����
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(false);
        }
    }

    void DisplayNextDialogue()
    {
        currentDialogueIndex++; // ���� ��ȭ �ε����� �̵�
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            dialogueText.text = dialogueTexts[currentDialogueIndex]; // ���� ��ȭ ����
        }
        else
        {
            EndDialogue(); // ��ȭ ���� �Լ� ȣ��
        }
    }

    void EndDialogue()
    {
        dialogueActive = false; // ��ȭ ��Ȱ��ȭ ���·� ����
        dialogueUI.SetActive(false); // ���̾�α� UI ��Ȱ��ȭ
        Debug.Log("��� ��ȭ�� �������ϴ�.");
        currentDialogueIndex = 0; // ��ȭ �ε��� �ʱ�ȭ

        // �÷��̾� ��Ʈ�ѷ��� ������ ���� ����
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(true);
        }
    }
}