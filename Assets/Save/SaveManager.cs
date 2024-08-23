using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public int playerHP = 5;
    public List<string> inventory = new List<string>();

    public Button saveButton;  // Save ��ư

    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = GetComponent<SaveSystem>();

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // Save ��ư Ŭ�� �� ���� ����
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveGame);
        }
        else
        {
            Debug.LogError("Save ��ư�� �������� �ʾҽ��ϴ�.");
        }
    }

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory);
            Debug.Log("������ ���������� ����Ǿ����ϴ�.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("���� ���� �� ���� �߻�: " + ex.Message);
        }
    }
}
