using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 추가

public class DialogueForStart : MonoBehaviour
{

    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    private bool dialogueActive = false; // 대화 활성화 여부를 나타내는 변수
    private string[] dialogueTexts = {
        "...",
        "이건 말도 안 돼.",
        "난 지구의 멸망을 막아야만 해.",
        "왜냐하면...",
        "왜냐하면...",
        "고양이를 구해야 하니까.",
        "당장 떠날 준비를 해야겠어."
    }; // 대화 텍스트 배열
    private int currentDialogueIndex = 0; // 현재 대화 인덱스
    public float typingSpeed = 0.05f; // 타이핑 속도
    public string nextSceneName = "NextScene"; // 다음 씬의 이름


    void Start()
    {
        dialogueActive = true; // 대화 활성화 상태로 변경
        dialogueUI.SetActive(true); // 시작 시 다이얼로그 UI 활성화
        DisplayNextDialogue(); // 첫 번째 대화 시작
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {
                DisplayNextDialogue(); // 다음 대화로 넘어가는 함수 호출
            }
            else
            {
                // 타이핑 중에 Enter 키를 누르면 모든 텍스트를 즉시 표시
                StopAllCoroutines();
                dialogueText.text = dialogueTexts[currentDialogueIndex];
                isTyping = false;
            }
        }
    }

    public void StartDialogue(string[] dialogues)
    {
        dialogueTexts = dialogues; // 대화 텍스트 배열 설정
        currentDialogueIndex = 0; // 대화 인덱스 초기화
        dialogueText.text = string.Empty; // 텍스트 초기화
        dialogueActive = true; // 대화 활성화 상태로 변경
        dialogueUI.SetActive(true); // 다이얼로그 UI 활성화
        DisplayNextDialogue(); // 첫 번째 대화 시작
    }

    void DisplayNextDialogue()
    {
        if (currentDialogueIndex < dialogueTexts.Length)
        {
            StartCoroutine(TypeSentence(dialogueTexts[currentDialogueIndex])); // 타이핑 애니메이션 시작
        }
        else
        {
            EndDialogue(); // 대화 종료 함수 호출
        }
    }

    private bool isTyping = false; // 타이핑 중인지 여부

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true; // 타이핑 중으로 설정
        dialogueText.text = ""; // 텍스트 초기화
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed); // 타이핑 속도에 따라 대기
        }
        isTyping = false; // 타이핑 완료
        currentDialogueIndex++; // 다음 대화 인덱스로 이동
    }

    void EndDialogue()
    {
        dialogueActive = false; // 대화 비활성화 상태로 변경
        dialogueUI.SetActive(false); // 다이얼로그 UI 비활성화
        Debug.Log("모든 대화가 끝났습니다.");
        currentDialogueIndex = 0; // 대화 인덱스 초기화
        SceneManager.LoadScene(nextSceneName); // 씬 변경
    }
}
