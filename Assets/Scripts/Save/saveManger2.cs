using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class saveManager2 : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button saveButton;
    public Button exitButton;
    public TMP_Text lastSavedTimeText;
    public TMP_Text planetNameText; // 행성 이름 텍스트
    public TMP_InputField planetNameInputField; // 행성 이름 입력 필드

    private SaveSystem saveSystem;
    public int playerHP = 100;
    public List<string> inventory = new List<string>();
    public string planetName = "DefaultPlanetName"; // 기본 행성 이름

    void Start()
    {
        // SaveSystem 싱글턴 인스턴스 사용
        saveSystem = SaveSystem.Instance;

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem 인스턴스를 찾을 수 없습니다.");
            return;
        }

        // 버튼 클릭 이벤트 설정
        if (newGameButton != null)
            newGameButton.onClick.AddListener(StartNewGame);

        if (loadGameButton != null)
            loadGameButton.onClick.AddListener(LoadGame);

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitToTitle);

        if (planetNameInputField != null)
            planetNameInputField.onValueChanged.AddListener(SetPlanetName);

        // 저장된 게임 정보 확인 및 시간 표시
        UpdateSavedInfo();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("PrologueScene"); // 새 게임 시작
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
                // 필요한 경우 데이터를 게임에 로드하는 추가 설정
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

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory, planetName);
            Debug.Log("게임이 성공적으로 저장되었습니다.");
            UpdateSavedInfo(); // 저장 후 정보를 업데이트
        }
        catch (Exception ex)
        {
            Debug.LogError("게임 저장 중 오류 발생: " + ex.Message);
        }
    }

    public void ExitToTitle()
    {
        // 저장 후 씬 전환
        StartCoroutine(ExitAfterSave());
    }

    private IEnumerator ExitAfterSave()
    {
        SaveGame();  // 저장 수행
        yield return new WaitForSeconds(1f); // 충분한 대기 시간

        // 타이틀 씬으로 이동
        SceneManager.LoadScene("Title");
    }

    public void SetPlanetName(string name)
    {
        planetName = name;
        Debug.Log("SetPlanetName 호출됨: " + planetName);
    }

    void UpdateSavedInfo()
    {
        Debug.Log("UpdateSavedInfo 호출됨");

        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                lastSavedTimeText.text = "Last Saved: " + saveData.saveTime;
                planetNameText.text = "Planet Name: " + saveData.planetName;
                Debug.Log("로딩된 행성 이름: " + saveData.planetName);
            }
            else
            {
                lastSavedTimeText.text = "No saved game";
                planetNameText.text = "Planet Name: ";
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
        if (newGameButton != null)
            newGameButton.onClick.AddListener(StartNewGame);

        if (loadGameButton != null)
            loadGameButton.onClick.AddListener(LoadGame);

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitToTitle);

        // 씬이 활성화될 때 저장된 정보를 업데이트
        UpdateSavedInfo();
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " 오브젝트가 파괴되었습니다.");
    }
}
