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
        "당신은 우주의 어딘가를 떠돌고 있다.",
        "아직 당신의 행성이 잘 보이지 않는다. 좀 더 확대할까?",
        "바로 이곳.",
        "이곳이 당신의 행성이다.",
        "행성의 이름은 무엇인가?",
        "{planetName}, 멋진 이름이다.",
        "{planetName}인, 행운을 빈다."
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
                // 타이핑 중 스페이스바를 누르면 타이핑을 중단하고 전체 텍스트 표시
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

            // 대화 내용에서 {planetName}을 실제 행성 이름으로 대체
            if (dialogueLine.Contains("{planetName}"))
            {
                dialogueLine = dialogueLine.Replace("{planetName}", planetName);
            }

            if (dialogueLine == "아직 당신의 행성이 잘 보이지 않는다. 좀 더 확대할까?")
            {
                StartCoroutine(ShowDialogueWithChoice(dialogueLine));
            }
            else if (dialogueLine == "행성의 이름은 무엇인가?")
            {
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(ShowDialogueWithInputField(dialogueLine));
            }
            else if (dialogueLine == "이곳이 당신의 행성이다.")
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
        Debug.Log("선택지 1을 선택했습니다.");
        choicePanel.SetActive(false);
        nextButton.gameObject.SetActive(true);
        currentLineIndex++;
        DisplayNextDialogue();
    }

    void ChooseOption2()
    {
        Debug.Log("선택지 2를 선택했습니다.");
        StartCoroutine(TypeSentence("다시 생각해보자."));
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
