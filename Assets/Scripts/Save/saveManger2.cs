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
    public TMP_Text planetNameText; // �༺ �̸� �ؽ�Ʈ
    public TMP_InputField planetNameInputField; // �༺ �̸� �Է� �ʵ�

    private SaveSystem saveSystem;
    public int playerHP = 100;
    public List<string> inventory = new List<string>();
    public string planetName = "DefaultPlanetName"; // �⺻ �༺ �̸�

    void Start()
    {
        // SaveSystem �̱��� �ν��Ͻ� ���
        saveSystem = SaveSystem.Instance;

        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem �ν��Ͻ��� ã�� �� �����ϴ�.");
            return;
        }

        // ��ư Ŭ�� �̺�Ʈ ����
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

        // ����� ���� ���� Ȯ�� �� �ð� ǥ��
        UpdateSavedInfo();
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("PrologueScene"); // �� ���� ����
    }

    public void LoadGame()
    {
        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                // ����� ������ ��ȯ
                SceneManager.LoadScene(saveData.sceneName);
                // �ʿ��� ��� �����͸� ���ӿ� �ε��ϴ� �߰� ����
                // SetupGameWithLoadedData(saveData);
            }
            else
            {
                Debug.LogWarning("����� �����Ͱ� �ùٸ��� �ʽ��ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("����� ������ �����ϴ�.");
        }
    }

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory, planetName);
            Debug.Log("������ ���������� ����Ǿ����ϴ�.");
            UpdateSavedInfo(); // ���� �� ������ ������Ʈ
        }
        catch (Exception ex)
        {
            Debug.LogError("���� ���� �� ���� �߻�: " + ex.Message);
        }
    }

    public void ExitToTitle()
    {
        // ���� �� �� ��ȯ
        StartCoroutine(ExitAfterSave());
    }

    private IEnumerator ExitAfterSave()
    {
        SaveGame();  // ���� ����
        yield return new WaitForSeconds(1f); // ����� ��� �ð�

        // Ÿ��Ʋ ������ �̵�
        SceneManager.LoadScene("Title");
    }

    public void SetPlanetName(string name)
    {
        planetName = name;
        Debug.Log("SetPlanetName ȣ���: " + planetName);
    }

    void UpdateSavedInfo()
    {
        Debug.Log("UpdateSavedInfo ȣ���");

        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            if (saveData != null)
            {
                lastSavedTimeText.text = "Last Saved: " + saveData.saveTime;
                planetNameText.text = "Planet Name: " + saveData.planetName;
                Debug.Log("�ε��� �༺ �̸�: " + saveData.planetName);
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
        // Ÿ��Ʋ ������ ���ƿ��� �� �̺�Ʈ �ٽ� ����
        if (newGameButton != null)
            newGameButton.onClick.AddListener(StartNewGame);

        if (loadGameButton != null)
            loadGameButton.onClick.AddListener(LoadGame);

        if (saveButton != null)
            saveButton.onClick.AddListener(SaveGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitToTitle);

        // ���� Ȱ��ȭ�� �� ����� ������ ������Ʈ
        UpdateSavedInfo();
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " ������Ʈ�� �ı��Ǿ����ϴ�.");
    }
}
