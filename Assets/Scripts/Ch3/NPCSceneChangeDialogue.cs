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
    public Button option1Button; // 선택지 1 버튼
    public Button option2Button; // 선택지 2 버튼

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
        option1Button.onClick.AddListener(OnOption1Clicked); // 선택지 1 클릭 이벤트 추가
        option2Button.onClick.AddListener(OnOption2Clicked); // 선택지 2 클릭 이벤트 추가

        option1Button.gameObject.SetActive(false); // 시작 시 선택지 버튼 숨기기
        option2Button.gameObject.SetActive(false); // 시작 시 선택지 버튼 숨기기
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
            ShowOptions(); // 대화가 끝나면 선택지 버튼 표시
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
        nextButton.gameObject.SetActive(false); // 다음 버튼 숨기기
        option1Button.gameObject.SetActive(true); // 선택지 1 버튼 표시
        option2Button.gameObject.SetActive(true); // 선택지 2 버튼 표시
    }

    void OnOption1Clicked()
    {
        SceneManager.LoadScene(nextScene); // "플로깅 연습하기"를 선택하면 씬 전환
    }

    void OnOption2Clicked()
    {
        EndDialogue(); // "하지 않는다"를 선택하면 대화 종료
    }
}
