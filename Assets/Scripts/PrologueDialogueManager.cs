using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologueDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public Button nextButton;
    public Image backgroundImage;

    public GameObject choicePanel;
    public Button choice1Button;
    public Button choice2Button;
    public TMP_InputField nameInputField;
    public Image fadeImage;

    private string[] dialogueLines = {
        "����� ������ ��򰡸� ������ �ִ�.",
        "���� ����� �༺�� �� ������ �ʴ´�. �� �� Ȯ���ұ�?",
        "�ٷ� �̰�.",
        "�̰��� ����� �༺�̴�.",
        "�༺�� �̸��� �����ΰ�?",
        "{planetName}, ���� �̸��̴�.",
        "{planetName}��, ����� ���."
    };

    public Sprite[] backgroundImages;

    private int currentLineIndex = 0;
    public string planetName = "";

    private bool isTyping = false;
    public float typingSpeed = 0.05f;

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);
        choice1Button.onClick.AddListener(ChooseOption1);
        choice2Button.onClick.AddListener(ChooseOption2);
        fadeImage.gameObject.SetActive(false);
        DisplayNextDialogue();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && !nameInputField.gameObject.activeInHierarchy)
        {
            if (isTyping)
            {
                // Ÿ���� �� �����̽��ٸ� ������ Ÿ������ �ߴ��ϰ� ��ü �ؽ�Ʈ ǥ��
                StopAllCoroutines();
                dialogueText.text = dialogueLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                DisplayNextDialogue();
            }
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
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(ShowDialogueWithInputField(dialogueLine));
            }
            else if (dialogueLine == "�̰��� ����� �༺�̴�.")
            {
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(TypeSentence(dialogueLine));
                currentLineIndex++;
            }
            else
            {
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
        yield return new WaitForSeconds(typingSpeed);
        nextButton.gameObject.SetActive(false);
        choicePanel.SetActive(true);
    }

    IEnumerator ShowDialogueWithInputField(string sentence)
    {
        yield return StartCoroutine(TypeSentence(sentence));
        nameInputField.gameObject.SetActive(true);
        nextButton.onClick.RemoveListener(DisplayNextDialogue);
        nextButton.onClick.AddListener(SubmitName);
    }

    void ChooseOption1()
    {
        Debug.Log("������ 1�� �����߽��ϴ�.");
        choicePanel.SetActive(false);
        nextButton.gameObject.SetActive(true);
        currentLineIndex++;
        DisplayNextDialogue();
    }

    void ChooseOption2()
    {
        Debug.Log("������ 2�� �����߽��ϴ�.");
        StartCoroutine(TypeSentence("�ٽ� �����غ���."));
        choicePanel.SetActive(false);
        nextButton.gameObject.SetActive(true);
        currentLineIndex--;
    }

    void SubmitName()
    {
        planetName = nameInputField.text;
        nameInputField.gameObject.SetActive(false);
        nextButton.onClick.RemoveListener(SubmitName);
        nextButton.onClick.AddListener(DisplayNextDialogue);
        currentLineIndex++;
        DisplayNextDialogue();
    }

    IEnumerator FadeOut()
    {
        float fadeDuration = 1.0f;
        float elapsedTime = 0f;

        fadeImage.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Ch1-1");
    }
}
