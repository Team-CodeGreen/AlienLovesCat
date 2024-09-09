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
    private string planetName = "DefaultPlanetName"; // �⺻ �༺ �̸�

    void Start()
    {
        // SaveSystem �̱��� �ν��Ͻ� ���
        saveSystem = SaveSystem.Instance;
        Debug.Log("Saving planet name: " + planetName); // ������ ���� �༺ �̸� ���
        if (saveSystem.HasSaveFile())
        {
            SaveData saveData = saveSystem.LoadGame();
            planetName = saveData.planetName ?? "DefaultPlanetName";
            UpdateSavedInfo(); // UpdateSavedInfo ȣ��
        }

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
        {
            planetNameInputField.onValueChanged.AddListener(OnPlanetNameChanged);
        }

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

                // ����� �༺ �̸��� ����
                planetName = saveData.planetName ?? "DefaultPlanetName";
                planetNameInputField.text = planetName; // �Է� �ʵ忡 ����� �༺ �̸� ����
                UpdateSavedInfo(); // ����� ���� ������Ʈ
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
            string sceneName = SceneManager.GetActiveScene().name;

            // ���� ����� �����Ϳ��� �༺ �̸��� ����������
            SaveData existingData = saveSystem.LoadGame();
            string savedPlanetName = existingData?.planetName ?? planetName;

            // �⺻���� �ƴ� ���� ����
            if (planetName != "DefaultPlanetName")
            {
                saveSystem.SaveGame(planetName, sceneName);
                Debug.Log("������ ���������� ����Ǿ����ϴ�.");
                UpdateSavedInfo(); // ���� �� ������ ������Ʈ
            }
            else
            {
                // �⺻���� ��� ���� ����� �����Ϳ��� �༺ �̸��� ���
                saveSystem.SaveGame(savedPlanetName, sceneName);
                Debug.Log("������ ���������� ����Ǿ����ϴ�. (�༺ �̸� �⺻���̶� �̸��� ������� ����)");
            }
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

    public void OnPlanetNameChanged(string name)
    {
        planetName = name;
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
                planetNameText.text = "Planet Name: " + (saveData.planetName ?? "DefaultPlanetName");
                Debug.Log("�ε��� �༺ �̸�: " + (saveData.planetName ?? "DefaultPlanetName"));
            }
            else
            {
                lastSavedTimeText.text = "No saved game";
                planetNameText.text = "Planet Name: DefaultPlanetName";
            }
        }
        else
        {
            lastSavedTimeText.text = "No saved game";
            planetNameText.text = "Planet Name: DefaultPlanetName";
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

        if (planetNameInputField != null)
        {
            planetNameInputField.onValueChanged.AddListener(OnPlanetNameChanged);
        }

        // ���� Ȱ��ȭ�� �� ����� ������ ������Ʈ
        UpdateSavedInfo();
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " ������Ʈ�� �ı��Ǿ����ϴ�.");
    }
}