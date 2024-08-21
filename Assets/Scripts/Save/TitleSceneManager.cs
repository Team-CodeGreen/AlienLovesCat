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
            Debug.LogError("SaveSystem 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        // 버튼 클릭 이벤트 설정
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);

        // 저장된 게임 정보 확인 및 시간 표시
        UpdateLastSavedTime();
    }

    void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");  // 새 게임 시작
    }

    void LoadGame()
    {
        if (saveSystem.HasSaveFile())
        {
            SceneManager.LoadScene("GameScene");  // 저장된 게임 불러오기
        }
        else
        {
            Debug.LogWarning("저장된 게임이 없습니다.");
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
