
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

    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = GetComponent<SaveSystem>();

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // ��ư Ŭ�� �̺�Ʈ ����
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);

        // ����� ���� ���� Ȯ�� �� �ð� ǥ��
        UpdateLastSavedTime();
    }

    void StartNewGame()
    {
        SceneManager.LoadScene("PrologueScene");  // �� ���� ����
    }

    void LoadGame()
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
}