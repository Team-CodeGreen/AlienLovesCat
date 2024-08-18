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
        SceneManager.LoadScene("GameScene");  // �� ���� ����
    }

    void LoadGame()
    {
        if (saveSystem.HasSaveFile())
        {
            SceneManager.LoadScene("GameScene");  // ����� ���� �ҷ�����
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
            DateTime lastSavedTime = saveSystem.GetLastSaveTime();
            lastSavedTimeText.text = "Last Saved: " + lastSavedTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else
        {
            lastSavedTimeText.text = "No saved game";
        }
    }
}
