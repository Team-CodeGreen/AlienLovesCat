using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;  // UI Text 객체를 참조
    public Button nextButton;  // UI Button 객체를 참조
    public Image backgroundImage; // UI Image 객체를 참조

    [TextArea(3, 10)]
    public string[] dialogueLines; // 대사를 유니티 에디터에서 설정할 수 있도록 public으로 변경

    public Sprite[] backgroundImages; // 배경 이미지 배열을 정의

    private int currentLineIndex = 0;
    public string planetName = ""; // 행성 이름 저장 변수

    private bool isTyping = false; // 타이핑 중인지 여부 확인
    public float typingSpeed = 0.05f; // 타이핑 속도

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);
        DisplayNextDialogue();
    }

    void Update()
    {
        // Return이나 Space 키로도 대화가 진행되도록 설정
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && !isTyping)
        {
            DisplayNextDialogue();
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
            // 대사가 모두 끝났을 때 처리할 내용을 여기에 추가 가능
            Debug.Log("대화가 끝났습니다.");
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
}
