using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public int playerHP = 5;
    public List<string> inventory = new List<string>();

    public Button saveButton;  // Save ��ư
    public Button exitButton;   // Exit ��ư

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
    { // �̱��� �ν��Ͻ��� ����
        saveSystem = SaveSystem.Instance;
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
        exitButton.onClick.AddListener(ExitToTitle);  // Exit ��ư Ŭ�� �̺�Ʈ ����
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
    public void ExitToTitle()
    {
        // Ÿ��Ʋ ������ �̵�
        SaveGame();
        SceneManager.LoadScene("Title");
        // ��� ����Ͽ� ������ �Ϸ�ǵ��� ����
        StartCoroutine(ExitAfterSave());
    }
    private IEnumerator ExitAfterSave()
    {
        yield return new WaitForEndOfFrame(); // �������� ���� ������ ���
        SceneManager.LoadScene("Title"); // Ÿ��Ʋ ������ �̵�
    }
    void OnDestroy()
    {
        Debug.Log(gameObject.name + " ������Ʈ�� �ı��Ǿ����ϴ�.");
    }
}
