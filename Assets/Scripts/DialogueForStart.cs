using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �߰�

public class DialogueForStart : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    private bool dialogueActive = false; // ��ȭ Ȱ��ȭ ���θ� ��Ÿ���� ����
    private string[] dialogueTexts = {
        "...",
        "�̰� ���� �� ��.",
        "�� ������ ����� ���ƾ߸� ��.",
        "�ֳ��ϸ�...",
        "�ֳ��ϸ�...",
        "����̸� ���ؾ� �ϴϱ�.",
        "���� ���� �غ� �ؾ߰ھ�."
    }; // ��ȭ �ؽ�Ʈ �迭
    private int currentDialogueIndex = 0; // ���� ��ȭ �ε���
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�
    public string nextSceneName = "NextScene"; // ���� ���� �̸�


    void Start()
    {
        dialogueActive = true; // ��ȭ Ȱ��ȭ ���·� ����
        dialogueUI.SetActive(true); // ���� �� ���̾�α� UI Ȱ��ȭ
        DisplayNextDialogue(); // ù ��° ��ȭ ����
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                DisplayNextDialogue(); // ���� ��ȭ�� �Ѿ�� �Լ� ȣ��
            }
            else
            {
                // Ÿ���� �߿� Enter Ű�� ������ ��� �ؽ�Ʈ�� ��� ǥ��
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
            }
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueTexts = dialogues; // ��ȭ �ؽ�Ʈ �迭 ����
        currentDialogueIndex = 0; // ��ȭ �ε��� �ʱ�ȭ
        dialogueText.text = string.Empty; // �ؽ�Ʈ �ʱ�ȭ
        dialogueActive = true; // ��ȭ Ȱ��ȭ ���·� ����
        dialogueUI.SetActive(true); // ���̾�α� UI Ȱ��ȭ
        DisplayNextDialogue(); // ù ��° ��ȭ ����
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // Ÿ���� �ִϸ��̼� ����
        }
        else
        {
            EndDialogue(); // ��ȭ ���� �Լ� ȣ��
        }
    }

    private bool isTyping = false; // Ÿ���� ������ ����

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true; // Ÿ���� ������ ����
        dialogueText.text = ""; // �ؽ�Ʈ �ʱ�ȭ
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // Ÿ���� �ӵ��� ���� ���
        }
        isTyping = false; // Ÿ���� �Ϸ�
        currentDialogueIndex++; // ���� ��ȭ �ε����� �̵�
    }

    void EndDialogue()
    {
        dialogueActive = false; // ��ȭ ��Ȱ��ȭ ���·� ����
        dialogueUI.SetActive(false); // ���̾�α� UI ��Ȱ��ȭ
        Debug.Log("��� ��ȭ�� �������ϴ�.");
        currentDialogueIndex = 0; // ��ȭ �ε��� �ʱ�ȭ
        SceneManager.LoadScene(nextSceneName); // �� ����
    }
}
