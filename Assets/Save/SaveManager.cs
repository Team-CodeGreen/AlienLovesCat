using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public int playerHP = 5;
    public List<string> inventory = new List<string>();

    public Button saveButton;  // Save 버튼

    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = GetComponent<SaveSystem>();

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
}
