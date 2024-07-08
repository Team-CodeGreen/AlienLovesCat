using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI Text 객체를 참조
    public Button nextButton;  // UI Button 객체를 참조
    public Image backgroundImage; //UI Image 객체를 참조


    public GameObject choicePanel;  // 선택지 패널
    public Button choice1Button;  // 선택지 1 버튼
    public Button choice2Button;  // 선택지 2 버튼

    private string[] dialogueLines = {
        "당신은 우주의 어딘가를 떠돌고 있다.",
        "아직 당신의 행성이 잘 보이지 않는다. 좀 더 확대할까?",
        "바로 이곳.",
        "이곳이 당신의 행성이다.",
        "행성의 이름은 무엇인가?"
    };

    public Sprite[] backgroundImages; //배경 이미지 배열을 정의

    private int currentLineIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);
        choice1Button.onClick.AddListener(ChooseOption1);
        choice2Button.onClick.AddListener(ChooseOption2);
        DisplayNextDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];

            // "좀 더 확대할까?"에서 선택지 표시
            if (dialogueLines[currentLineIndex] == "아직 당신의 행성이 잘 보이지 않는다. 좀 더 확대할까?")
            {
                nextButton.gameObject.SetActive(false);  // 다음 버튼을 숨김
                choicePanel.SetActive(true);  // 선택지 패널을 활성화
            }
            else
            {
                // 배경 이미지 변경
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                currentLineIndex++;
            }
        }
        else
        {
            dialogueText.text = "대화가 끝났습니다.";
            nextButton.gameObject.SetActive(false);  // 대화가 끝나면 버튼을 비활성화
        }
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
        dialogueText.text = "다시 생각해보자.";
        choicePanel.SetActive(false);  // 선택지 패널을 숨깁니다.
        nextButton.gameObject.SetActive(true);  // 다음 버튼을 다시 표시
        currentLineIndex--;  // 이전 대화로 돌아감
    }
}
