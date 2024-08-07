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
    public Button nextButton; // ��ư ���� �߰�

    private bool dialogueActive = false; // ��ȭ Ȱ��ȭ ���θ� ��Ÿ���� ����
    private string[] dialogueTexts; // ��ȭ �ؽ�Ʈ �迭
    private int currentDialogueIndex = 0; // ���� ��ȭ �ε���
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�

    private bool isTyping = false;

    void Start()
    {
        dialogueUI.SetActive(false); // ���� �� ���̾�α� UI ��Ȱ��ȭ
        nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            OnNextButtonClicked(); // ���� Ű�� �����̽��ٸ� ������ �� OnNextButtonClicked ȣ��
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueActive = true; // ��ȭ Ȱ��ȭ ���·� ����
        dialogueTexts = dialogues; // ��ȭ �ؽ�Ʈ �迭 ����
        dialogueUI.SetActive(true); // ���̾�α� UI Ȱ��ȭ
        currentDialogueIndex = 0; // ��ȭ �ε��� �ʱ�ȭ
        StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // ù ��° ��ȭ ����

        // �÷��̾� ��Ʈ�ѷ��� ������ ����
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementEnabled(false);
        }
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // ���� ��ȭ ����
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

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void OnNextButtonClicked() // ��ư Ŭ�� �� ȣ��� �޼��� �߰�
    {
        if (dialogueActive)
        {
            if (!isTyping)
            {
                currentDialogueIndex++; // ���� �ε����� ���⼭ ������Ű���� �̵�
                DisplayNextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
                currentDialogueIndex++; // ���� �ε����� ���⼭ ������Ű���� �̵�
            }
        }
    }
}