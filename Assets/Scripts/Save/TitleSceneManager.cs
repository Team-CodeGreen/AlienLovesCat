using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SaveSystem;

public class TitleSceneManager : MonoBehaviour
{

    public Button newGameButton;
    public Button loadGameButton;
    public TMP_Text lastSavedTimeText;
    public TMP_Text planetNameText; // �༺ �̸� �ؽ�Ʈ �߰�

    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = SaveSystem.Instance; // �̱��� �ν��Ͻ� ���

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem �ν��Ͻ��� ã�� �� �����ϴ�.");
            return;
        }

        // ��ư Ŭ�� �̺�Ʈ ����
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);

        // ����� ���� ���� Ȯ�� �� �ð� ǥ��
        UpdateSavedInfo();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("PrologueScene");  // �� ���� ����
    }

    public void LoadGame()
    {
        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                // ����� ������ ��ȯ
                SceneManager.LoadScene(saveData.sceneName);

                // ������ �ε� �� �ʿ��� ������ �߰��� �� �ֽ��ϴ�.
                // ���� ���:
                // SetupGameWithLoadedData(saveData);
            }
            else
            {
                Debug.LogWarning("����� �����Ͱ� �ùٸ��� �ʽ��ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("����� ������ �����ϴ�.");
        }
    }

    void UpdateLastSavedTime()
    {
        if (saveSystem.HasSaveFile())
        {
            string lastSavedTime = saveSystem.GetLastSaveTime();
            lastSavedTimeText.text = "Last Saved: " + lastSavedTime;

            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                Debug.Log("�ε�� �༺ �̸�: " + saveData.planetName); // ����� �α� �߰�
                planetNameText.text = "Planet Name: " + saveData.planetName;
            }
            else
            {
                planetNameText.text = "Planet Name:";
            }
        }
        else
        {
            lastSavedTimeText.text = "No saved game";
            planetNameText.text = "Planet Name: ";
        }
    }
    void OnEnable()
    {
        // Ÿ��Ʋ ������ ���ƿ��� �� �̺�Ʈ �ٽ� ����
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        // ���� Ȱ��ȭ�� �� ����� ������ ������Ʈ
        UpdateSavedInfo();
    }

    void UpdateSavedInfo()
    {
        // saveSystem�� ����� �ʱ�ȭ�Ǿ����� Ȯ��
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            return;
        }

        // saveSystem�� null�� �ƴ� ���� HasSaveFile()�� ȣ��
        if (saveSystem.HasSaveFile())
        {
            string lastSavedTime = saveSystem.GetLastSaveTime();
            lastSavedTimeText.text = "Last Saved: " + lastSavedTime;

            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                planetNameText.text = "Planet Name: " + saveData.planetName;
            }
            else
            {
                planetNameText.text = "Planet Name: ";
            }
        }
        else
        {
            lastSavedTimeText.text = "No saved game";
            planetNameText.text = "Planet Name: ";
        }
    }
}