using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public int playerHP = 5;
    public List<string> inventory = new List<string>();

    public Button saveButton;  // Save 버튼
    public Button exitButton;   // Exit 버튼

    private SaveSystem saveSystem;
    private static SaveManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           //Destroy(gameObject);
        }
    }
    void Start()
    { // 싱글턴 인스턴스에 접근
        saveSystem = SaveSystem.Instance;
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        // Save 버튼 클릭 시 게임 저장
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveGame);
        }
        else
        {
            Debug.LogError("Save 버튼이 설정되지 않았습니다.");
        }
        exitButton.onClick.AddListener(ExitToTitle);  // Exit 버튼 클릭 이벤트 연결
    }

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory);
            Debug.Log("게임이 성공적으로 저장되었습니다.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("게임 저장 중 오류 발생: " + ex.Message);
        }
    }
    public void ExitToTitle()
    {
        // 타이틀 씬으로 이동
        SaveGame();
        SceneManager.LoadScene("Title");
        // 잠시 대기하여 저장이 완료되도록 보장
        StartCoroutine(ExitAfterSave());
    }
    private IEnumerator ExitAfterSave()
    {
        yield return new WaitForEndOfFrame(); // 프레임이 끝날 때까지 대기
        SceneManager.LoadScene("Title"); // 타이틀 씬으로 이동
    }
    void OnDestroy()
    {
        Debug.Log(gameObject.name + " 오브젝트가 파괴되었습니다.");
    }
}
