using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;  // UI Text ��ü�� ����
    public Button nextButton;  // UI Button ��ü�� ����
    public Image backgroundImage; //UI Image ��ü�� ����


    public GameObject choicePanel;  // ������ �г�
    public Button choice1Button;  // ������ 1 ��ư
    public Button choice2Button;  // ������ 2 ��ư
    public InputField nameInputField; // �̸� �Է� �ʵ�


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
        if (currentLineIndex == 4)
        {
            // �̸� �Է� �ܰ迡�� �̸��� ����
            dialogueText.text = dialogueLines[currentLineIndex];
            nameInputField.gameObject.SetActive(true); // �̸� �Է� �ʵ� Ȱ��ȭ
            nextButton.onClick.RemoveListener(DisplayNextDialogue); // ���� ������ ����
            nextButton.onClick.AddListener(SubmitName); // �̸� ���� ������ �߰�
            return;
        }

        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];

            // ��ȭ ���뿡�� {planetName}�� ���� �༺ �̸����� ��ü
            if (dialogueText.text.Contains("{planetName}"))
            {
                dialogueText.text = dialogueText.text.Replace("{planetName}", planetName);
            }

            // "�� �� Ȯ���ұ�?"���� ������ ǥ��
            if (dialogueLines[currentLineIndex] == "���� ����� �༺�� �� ������ �ʴ´�. �� �� Ȯ���ұ�?")
            {
                nextButton.gameObject.SetActive(false);  // ���� ��ư�� ����
                choicePanel.SetActive(true);  // ������ �г��� Ȱ��ȭ
            }
            else
            {
                // ��� �̹��� ����
                if (currentLineIndex < backgroundImages.Length)
                {
                    backgroundImage.sprite = backgroundImages[currentLineIndex];
                }
                currentLineIndex++;
            }
        }
        else
        {
            dialogueText.text = "��ȭ�� �������ϴ�.";
            nextButton.gameObject.SetActive(false);  // ��ȭ�� ������ ��ư�� ��Ȱ��ȭ
        }
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
        dialogueText.text = "�ٽ� �����غ���.";
        choicePanel.SetActive(false);  // ������ �г��� ����ϴ�.
        nextButton.gameObject.SetActive(true);  // ���� ��ư�� �ٽ� ǥ��
        currentLineIndex--;  // ���� ��ȭ�� ���ư�
    }

    void SubmitName()
    {
        planetName = nameInputField.text; // �༺ �̸� ����
        nameInputField.gameObject.SetActive(false); // �Է� �ʵ� ����
        nextButton.onClick.RemoveListener(SubmitName); // ������ ����
        nextButton.onClick.AddListener(DisplayNextDialogue); // ���� ������ ����

        // �̸� �Է� ������ ��ȭ ������Ʈ
        currentLineIndex++;  // ���� ��ȭ�� ����
        DisplayNextDialogue();  // ���� ��ȭ ǥ��
    }
}
