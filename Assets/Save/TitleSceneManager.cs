
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        UpdateLastSavedTime();
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
            Debug.Log("Last saved time from file: " + lastSavedTime);
            lastSavedTimeText.text = "Last Saved: " + lastSavedTime;
        }
        else
        {
            Debug.LogWarning("No saved game found.");
            lastSavedTimeText.text = "No saved game";
        }
    }
    void OnEnable()
    {
        // Ÿ��Ʋ ������ ���ƿ��� �� �̺�Ʈ �ٽ� ����
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        // ���� Ȱ��ȭ�� �� ����� ������ ������Ʈ
        UpdateLastSavedTime();
    }
}