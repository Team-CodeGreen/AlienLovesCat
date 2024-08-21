using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;  // UI Text ��ü�� ����
    public Button nextButton;  // UI Button ��ü�� ����
    public Image backgroundImage; // UI Image ��ü�� ����

    public GameObject choicePanel;  // ������ �г�
    public Button choice1Button;  // ������ 1 ��ư
    public Button choice2Button;  // ������ 2 ��ư
    public TMP_InputField nameInputField; // �̸� �Է� �ʵ�
    public Image fadeImage;  // ���̵�ƿ��� ����� ���� �̹���
    public TMP_Text warningText; // ��� �޽��� �ؽ�Ʈ (�༺ �̸��� �Է��ϼ���)
    public TMP_Text warningText2; // ��� �޽��� �ؽ�Ʈ (10�� ������ �Է� ����)

    private string[] dialogueLines = {
        "����� ������ ��򰡸� ������ �ִ�.",
        "���� ����� �༺�� �� ������ �ʴ´�. �� �� Ȯ���ұ�?",
        "�ٷ� �̰�.",
        "�̰��� ����� �༺�̴�.",
        "�༺�� �̸��� �����ΰ�?",
        "{planetName}, ���� �̸��̴�.",
        "{planetName}��, ����� ���."
    };

    public Sprite[] backgroundImages; // ��� �̹��� �迭�� ����

    private int currentLineIndex = 0;
    public string planetName = ""; // �༺ �̸� ���� ����

    private bool isTyping = false; // Ÿ���� ������ ���� Ȯ��
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);
        choice1Button.onClick.AddListener(ChooseOption1);
        choice2Button.onClick.AddListener(ChooseOption2);
        nameInputField.characterLimit = 10; // ���ڼ� ����
        nameInputField.onValueChanged.AddListener(HandleInputChange); // ���ڼ� ���� �ڵ鷯 �߰�

        fadeImage.gameObject.SetActive(false); // ���� �� ���̵� �̹��� ��Ȱ��ȭ
        warningText.gameObject.SetActive(false); // ��� �޽��� ��Ȱ��ȭ
        warningText2.gameObject.SetActive(false); 
        DisplayNextDialogue();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && !isTyping && !nameInputField.gameObject.activeInHierarchy)
        {
            DisplayNextDialogue();
        }
    }
    void HandleInputChange(string input)
    {
        // �Էµ� ���ڰ� 10���ڸ� ������ �߶󳻱�
        if (input.Length > 10)
        {
            nameInputField.text = input.Substring(0, 10);
            StartCoroutine(ShowWarning("10�ڱ����� �Է��� �� �ֽ��ϴ�."));
        }
    }

    void DisplayNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            string dialogueLine = dialogueLines[currentLineIndex];

            // ��ȭ ���뿡�� {planetName}�� ���� �༺ �̸����� ��ü
            if (dialogueLine.Contains("{planetName}"))
            {
                dialogueLine = dialogueLine.Replace("{planetName}", planetName);
            }

            if (dialogueLine == "���� ����� �༺�� �� ������ �ʴ´�. �� �� Ȯ���ұ�?")
            {
                StartCoroutine(ShowDialogueWithChoice(dialogueLine));
            }
            else if (dialogueLine == "�༺�� �̸��� �����ΰ�?")
            {
                // ��� �̹��� ����
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(ShowDialogueWithInputField(dialogueLine));
            }
            else if (dialogueLine == "�̰��� ����� �༺�̴�.")
            {
                // ��� �̹��� ����
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(TypeSentence(dialogueLine));
                currentLineIndex++;
            }
            else
            {
                // ��� �̹��� ����
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(TypeSentence(dialogueLine));
                currentLineIndex++;
            }
        }
        else
        {
            StartCoroutine(FadeOut());
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

    IEnumerator ShowDialogueWithChoice(string sentence)
    {
        yield return StartCoroutine(TypeSentence(sentence));
        yield return new WaitForSeconds(typingSpeed); // ��� ��� �� ������ ǥ��
        nextButton.gameObject.SetActive(false);  // ���� ��ư�� ����
        choicePanel.SetActive(true);  // ������ �г��� Ȱ��ȭ
    }

    IEnumerator ShowDialogueWithInputField(string sentence)
    {
        yield return StartCoroutine(TypeSentence(sentence));
        nameInputField.characterLimit = 10; // ���ڼ� ����
        nameInputField.gameObject.SetActive(true); // �̸� �Է� �ʵ� Ȱ��ȭ
        nextButton.onClick.RemoveListener(DisplayNextDialogue); // ���� ������ ����
        nextButton.onClick.AddListener(SubmitName); // �̸� ���� ������ �߰�
    }

    void ChooseOption1()
    {
        // ������ 1�� ���� ó���� ���⿡ �����մϴ�.
        Debug.Log("������ 1�� �����߽��ϴ�.");
        choicePanel.SetActive(false);  // ������ �г��� ����ϴ�.
        nextButton.gameObject.SetActive(true);  // ���� ��ư�� �ٽ� ǥ��
        currentLineIndex++;  // ���� ��ȭ�� ����
        DisplayNextDialogue();  // ���� ��ȭ ǥ��
    }

    void ChooseOption2()
    {
        // ������ 2�� ���� ó���� ���⿡ �����մϴ�.
        Debug.Log("������ 2�� �����߽��ϴ�.");
        StartCoroutine(TypeSentence("�ٽ� �����غ���.")); // Ÿ���� �ִϸ��̼� ����
        choicePanel.SetActive(false);  // ������ �г��� ����ϴ�.
        nextButton.gameObject.SetActive(true);  // ���� ��ư�� �ٽ� ǥ��
        currentLineIndex--;  // ���� ��ȭ�� ���ư�
    }

    void SubmitName()
    {
        planetName = nameInputField.text;

        if (string.IsNullOrEmpty(planetName))
        {
            StartCoroutine(ShowWarning("�༺�� �̸��� �Է��ϼ���."));
            return; // �Է°��� ������ �Լ� ����
        }

        nameInputField.gameObject.SetActive(false); // �Է� �ʵ� ����
        nextButton.onClick.RemoveListener(SubmitName); // ������ ����
        nextButton.onClick.AddListener(DisplayNextDialogue); // ���� ������ ����

        // �̸� �Է� ������ ��ȭ ������Ʈ
        currentLineIndex++;  // ���� ��ȭ�� ����
        DisplayNextDialogue();  // ���� ��ȭ ǥ��
    }

    IEnumerator ShowWarning(string warningMessage)
    {
        warningText.text = warningMessage;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f); // ��� �޽��� ǥ�� �ð�
        warningText.gameObject.SetActive(false);
    }
    IEnumerator FadeOut()
    {
        float fadeDuration = 1.0f; // ���̵�ƿ� ���� �ð�
        float elapsedTime = 0f;

        fadeImage.gameObject.SetActive(true); // ���̵� �̹��� Ȱ��ȭ
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0;
        fadeImage.color = fadeColor;

        while (elapsedTime < fadeDuration)
        {
            fadeColor.a = elapsedTime / fadeDuration;
            fadeImage.color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeColor.a = 1;
        fadeImage.color = fadeColor;
        SceneManager.LoadScene("Ch1-1"); // �� ����
    }
}
