using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LastDialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;  // UI Text ��ü�� ����
    public Button nextButton;  // UI Button ��ü�� ����
    public Image backgroundImage; // UI Image ��ü�� ����

    [TextArea(3, 10)]
    public string[] dialogueLines; // ��縦 ����Ƽ �����Ϳ��� ������ �� �ֵ��� public���� ����

    public Sprite[] backgroundImages; // ��� �̹��� �迭�� ����

    private int currentLineIndex = 0;
    public string planetName = ""; // �༺ �̸� ���� ����

    private bool isTyping = false; // Ÿ���� ������ ���� Ȯ��
    public float typingSpeed = 0.05f; // Ÿ���� �ӵ�

    void Start()
    {
        nextButton.onClick.AddListener(DisplayNextDialogue);
        DisplayNextDialogue();
    }

    void Update()
    {
        // Return�̳� Space Ű�ε� ��ȭ�� ����ǵ��� ����
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

            // ��ȭ ���뿡�� {planetName}�� ���� �༺ �̸����� ��ü
            if (dialogueLine.Contains("{planetName}"))
            {
                dialogueLine = dialogueLine.Replace("{planetName}", planetName);
            }

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
            // ��簡 ��� ������ �� ó���� ������ ���⿡ �߰� ����
            Debug.Log("��ȭ�� �������ϴ�.");
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
