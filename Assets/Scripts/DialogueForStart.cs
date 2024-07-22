using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �� ������ ���� �߰�

public class DialogueForStart : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public Button nextButton; // ��ư ���� �߰�

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
        dialogueActive = true;
        dialogueUI.SetActive(true);
        nextButton.onClick.AddListener(OnNextButtonClicked); // ��ư Ŭ�� �̺�Ʈ �߰�
        DisplayNextDialogue();
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                DisplayNextDialogue();
            }
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueTexts = dialogues;
        currentDialogueIndex = 0;
        dialogueText.text = string.Empty;
        dialogueActive = true;
        dialogueUI.SetActive(true);
        DisplayNextDialogue();
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex]));
        }
        else
        {
            EndDialogue();
        }
    }

    private bool isTyping = false;

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
        currentDialogueIndex++;
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        Debug.Log("��� ��ȭ�� �������ϴ�.");
        currentDialogueIndex = 0;
        SceneManager.LoadScene(nextSceneName);
    }

    void OnNextButtonClicked() // ��ư Ŭ�� �� ȣ��� �޼��� �߰�
    {
        if (dialogueActive)
        {
            if (!isTyping)
            {
                DisplayNextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
            }
        }
    }
}
