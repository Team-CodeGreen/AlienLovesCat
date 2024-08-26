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
    public TMP_Text planetNameText; // 행성 이름 텍스트 추가

    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = SaveSystem.Instance; // 싱글턴 인스턴스 사용

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem 인스턴스를 찾을 수 없습니다.");
            return;
        }

        // 버튼 클릭 이벤트 설정
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);

        // 저장된 게임 정보 확인 및 시간 표시
        UpdateSavedInfo();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("PrologueScene");  // 새 게임 시작
    }

    public void LoadGame()
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
            lastSavedTimeText.text = "Last Saved: " + lastSavedTime;

            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                Debug.Log("로드된 행성 이름: " + saveData.planetName); // 디버그 로그 추가
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
        // 타이틀 씬으로 돌아왔을 때 이벤트 다시 설정
        newGameButton.onClick.AddListener(StartNewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        // 씬이 활성화될 때 저장된 정보를 업데이트
        UpdateSavedInfo();
    }

    void UpdateSavedInfo()
    {
        // saveSystem이 제대로 초기화되었는지 확인
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem이 초기화되지 않았습니다.");
            return;
        }

        // saveSystem이 null이 아닐 때만 HasSaveFile()을 호출
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