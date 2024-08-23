using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PrologueDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;  // UI Text 객체를 참조
    public Button nextButton;  // UI Button 객체를 참조
    public Image backgroundImage; // UI Image 객체를 참조

    public GameObject choicePanel;  // 선택지 패널
    public Button choice1Button;  // 선택지 1 버튼
    public Button choice2Button;  // 선택지 2 버튼
    public TMP_InputField nameInputField; // 이름 입력 필드
    public Image fadeImage;  // 페이드아웃에 사용할 검은 이미지
    public TMP_Text warningText; // 경고 메시지 텍스트 (행성 이름을 입력하세요)
    public TMP_Text warningText2; // 경고 메시지 텍스트 (10자 까지만 입력 가능)

    // 추가: playerHP와 inventory 변수
    public int playerHP = 5; // 기본값 설정
    public List<string> inventory = new List<string>();

    private string[] dialogueLines = {
        "당신은 우주의 어딘가를 떠돌고 있다.",
        "아직 당신의 행성이 잘 보이지 않는다. 좀 더 확대할까?",
        "바로 이곳.",
        "이곳이 당신의 행성이다.",
        "행성의 이름은 무엇인가?",
        "{planetName}, 멋진 이름이다.",
        "{planetName}인, 행운을 빈다."
    };

    public Sprite[] backgroundImages; // 배경 이미지 배열을 정의

    private int currentLineIndex = 0;
    public string planetName = ""; // 행성 이름 저장 변수

    private bool isTyping = false; // 타이핑 중인지 여부 확인
    public float typingSpeed = 0.05f; // 타이핑 속도
    private SaveManager saveManager;
    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
        if (saveManager == null)
        {
            Debug.LogError("SaveManager를 찾을 수 없습니다.");
        }
        else
        {
            playerHP = saveManager.playerHP;
            inventory = saveManager.inventory;
        }

        nextButton.onClick.AddListener(DisplayNextDialogue);
        choice1Button.onClick.AddListener(ChooseOption1);
        choice2Button.onClick.AddListener(ChooseOption2);
        nameInputField.characterLimit = 10;
        nameInputField.onValueChanged.AddListener(HandleInputChange);

        fadeImage.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
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
        // 입력된 글자가 10글자를 넘으면 잘라내기
        if (input.Length > 10)
        {
            nameInputField.text = input.Substring(0, 10);
            StartCoroutine(ShowWarning("10자까지만 입력할 수 있습니다."));
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
                // 배경 이미지 변경
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(ShowDialogueWithInputField(dialogueLine));
            }
            else if (dialogueLine == "이곳이 당신의 행성이다.")
            {
                // 배경 이미지 변경
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                StartCoroutine(TypeSentence(dialogueLine));
                currentLineIndex++;
            }
            else
            {
                // 배경 이미지 변경
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
        yield return new WaitForSeconds(typingSpeed); // 잠시 대기 후 선택지 표시
        nextButton.gameObject.SetActive(false);  // 다음 버튼을 숨김
        choicePanel.SetActive(true);  // 선택지 패널을 활성화
    }

    IEnumerator ShowDialogueWithInputField(string sentence)
    {
        yield return StartCoroutine(TypeSentence(sentence));
        nameInputField.characterLimit = 10; // 글자수 제한
        nameInputField.gameObject.SetActive(true); // 이름 입력 필드 활성화
        nextButton.onClick.RemoveListener(DisplayNextDialogue); // 기존 리스너 제거
        nextButton.onClick.AddListener(SubmitName); // 이름 제출 리스너 추가
    }

    void ChooseOption1()
    {
        // 선택지 1에 대한 처리를 여기에 구현합니다.
        Debug.Log("선택지 1을 선택했습니다.");
        choicePanel.SetActive(false);  // 선택지 패널을 숨깁니다.
        nextButton.gameObject.SetActive(true);  // 다음 버튼을 다시 표시
        currentLineIndex++;  // 다음 대화로 진행
        DisplayNextDialogue();  // 다음 대화 표시
    }

    void ChooseOption2()
    {
        // 선택지 2에 대한 처리를 여기에 구현합니다.
        Debug.Log("선택지 2를 선택했습니다.");
        StartCoroutine(TypeSentence("다시 생각해보자.")); // 타이핑 애니메이션 적용
        choicePanel.SetActive(false);  // 선택지 패널을 숨깁니다.
        nextButton.gameObject.SetActive(true);  // 다음 버튼을 다시 표시
        currentLineIndex--;  // 이전 대화로 돌아감
    }

    void DebugSaveData(SaveData saveData)
    {
        Debug.Log($"HP: {saveData.hp}");
        Debug.Log($"Inventory Items: {string.Join(", ", saveData.inventoryItems)}");
        Debug.Log($"Save Time: {saveData.saveTime}");
        Debug.Log($"Scene Name: {saveData.sceneName}");
        Debug.Log($"Planet Name: {saveData.planetName}");
    }

    void SubmitName()
    {
        planetName = nameInputField.text;

        if (string.IsNullOrEmpty(planetName))
        {
            StartCoroutine(ShowWarning("행성의 이름을 입력하세요."));
            return;
        }

        nameInputField.gameObject.SetActive(false);
        nextButton.onClick.RemoveListener(SubmitName);
        nextButton.onClick.AddListener(DisplayNextDialogue);

        currentLineIndex++;
        DisplayNextDialogue();
        // 로그 추가
        Debug.Log("제출된 행성 이름: " + planetName);

        // 저장 호출
        try
        {
            SaveSystem.Instance.SaveGame(playerHP, inventory, planetName);
            Debug.Log("게임 저장 완료. 행성 이름: " + planetName); // 디버그 로그 추가
        }
        catch (Exception ex)
        {
            Debug.LogError("게임 저장 중 오류 발생: " + ex.Message);
        }

        // 저장된 데이터 확인
        SaveData loadedData = SaveSystem.Instance.LoadGame();
        if (loadedData != null)
        {
            Debug.Log($"저장된 행성 이름: {loadedData.planetName}"); // 디버그 로그 추가
        }
    }
    IEnumerator ShowWarning(string warningMessage)
    {
        warningText.text = warningMessage;
        warningText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f); // 경고 메시지 표시 시간
        warningText.gameObject.SetActive(false);
    }
    IEnumerator FadeOut()
    {
        float fadeDuration = 1.0f; // 페이드아웃 지속 시간
        float elapsedTime = 0f;

        fadeImage.gameObject.SetActive(true); // 페이드 이미지 활성화
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
        SceneManager.LoadScene("Ch1-1"); // 씬 변경
    }
}
