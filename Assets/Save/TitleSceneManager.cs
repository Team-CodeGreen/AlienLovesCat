
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
        SceneManager.LoadScene("PrologueScene");  // 새 게임 시작
    }

    void LoadGame()
    {
        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                // 저장된 씬으로 전환
                SceneManager.LoadScene(saveData.sceneName);

                // 데이터 로드 후 필요한 설정을 추가할 수 있습니다.
                // 예를 들어:
                // SetupGameWithLoadedData(saveData);
            }
            else
            {
                Debug.LogWarning("저장된 데이터가 올바르지 않습니다.");
            }
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