using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCSceneChangeDialogue : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;
    public Button nextButton;
    public Button option1Button; // ������ 1 ��ư
    public Button option2Button; // ������ 2 ��ư

    public Image npcImage;
    public TMP_Text npcNameText;

    private bool dialogueActive = false;
    private string[] dialogueTexts;
    private int currentDialogueIndex = 0;
    public float typingSpeed = 0.05f;

    private bool isTyping = false;

    public string nextScene;

    void Start()
    {
        dialogueUI.SetActive(false);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        option1Button.onClick.AddListener(OnOption1Clicked); // ������ 1 Ŭ�� �̺�Ʈ �߰�
        option2Button.onClick.AddListener(OnOption2Clicked); // ������ 2 Ŭ�� �̺�Ʈ �߰�

        option1Button.gameObject.SetActive(false); // ���� �� ������ ��ư �����
        option2Button.gameObject.SetActive(false); // ���� �� ������ ��ư �����
    }

    void Update()
    {
        if (dialogueActive && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            OnNextButtonClicked();
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueActive = true;
        dialogueTexts = dialogues;
        dialogueUI.SetActive(true);
        currentDialogueIndex = 0;
        StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex]));

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
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex]));
        }
        else
        {
            ShowOptions(); // ��ȭ�� ������ ������ ��ư ǥ��
        }
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
        currentDialogueIndex = 0;

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

    void OnNextButtonClicked()
    {
        if (dialogueActive)
        {
            if (!isTyping)
            {
                currentDialogueIndex++;
                DisplayNextDialogue();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
                currentDialogueIndex++;
            }
        }
    }

    void ShowOptions()
    {
        nextButton.gameObject.SetActive(false); // ���� ��ư �����
        option1Button.gameObject.SetActive(true); // ������ 1 ��ư ǥ��
        option2Button.gameObject.SetActive(true); // ������ 2 ��ư ǥ��
    }

    void OnOption1Clicked()
    {
        SceneManager.LoadScene(nextScene); // "�÷α� �����ϱ�"�� �����ϸ� �� ��ȯ
    }

    void OnOption2Clicked()
    {
        EndDialogue(); // "���� �ʴ´�"�� �����ϸ� ��ȭ ����
    }
}
