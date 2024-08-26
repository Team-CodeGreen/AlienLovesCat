using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    public int playerHP = 5;
    public List<string> inventory = new List<string>();
    public string planetName = "DefaultPlanetName"; // 기본 행성 이름

    public Button saveButton;  // Save 버튼
    public Button exitButton;  // Exit 버튼
    public TMP_InputField planetNameInputField; // InputField 선언

    private SaveSystem saveSystem;
    private static SaveManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SaveManager 인스턴스 생성됨");
        }
        else
        {
            //Destroy(gameObject);  // 이미 존재하는 인스턴스가 있으면 현재 오브젝트를 파괴
            Debug.Log("기존 SaveManager 인스턴스 사용");
        }
    }

    void Start()
    {
        // 싱글턴 인스턴스에 접근
        saveSystem = SaveSystem.Instance;
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        // 플레이어 HP 및 인벤토리 초기화 예제
        playerHP = 100; // 또는 게임의 다른 부분에서 적절한 값으로 설정
        inventory = new List<string>(); // 예제 초기화

        // Save 버튼 클릭 시 게임 저장
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveGame);
        }
        else
        {
            Debug.LogError("Save 버튼이 설정되지 않았습니다.");
        }

        // Exit 버튼 클릭 시 타이틀 씬으로 이동
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitToTitle);
        }
        else
        {
            Debug.LogError("Exit 버튼이 설정되지 않았습니다.");
        }

        // InputField 리스너 설정
        if (planetNameInputField != null)
        {
            planetNameInputField.onValueChanged.AddListener(SetPlanetName);
        }
        else
        {
            Debug.LogError("Planet Name InputField가 설정되지 않았습니다.");
        }
    }

    public void SetPlanetName(string name)
    {
        planetName = name;
        Debug.Log("SetPlanetName 호출됨: " + planetName);
    }

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory, planetName);  // planetName을 사용하여 저장
            Debug.Log("게임이 성공적으로 저장되었습니다.");
        }
        catch (System.Exception ex)
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
        //SaveGame();  // 저장 수행
        yield return new WaitForSeconds(1f); // 충분한 대기 시간

        // 타이틀 씬으로 이동
        SceneManager.LoadScene("Title");
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " 오브젝트가 파괴되었습니다.");
    }
}