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
    public string planetName = "DefaultPlanetName"; // �⺻ �༺ �̸�

    public Button saveButton;  // Save ��ư
    public Button exitButton;  // Exit ��ư
    public TMP_InputField planetNameInputField; // InputField ����

    private SaveSystem saveSystem;
    private static SaveManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SaveManager �ν��Ͻ� ������");
        }
        else
        {
            //Destroy(gameObject);  // �̹� �����ϴ� �ν��Ͻ��� ������ ���� ������Ʈ�� �ı�
            Debug.Log("���� SaveManager �ν��Ͻ� ���");
        }
    }

    void Start()
    {
        // �̱��� �ν��Ͻ��� ����
        saveSystem = SaveSystem.Instance;
        if (saveSystem == null)
        {
            Debug.LogError("SaveSystem ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // �÷��̾� HP �� �κ��丮 �ʱ�ȭ ����
        playerHP = 100; // �Ǵ� ������ �ٸ� �κп��� ������ ������ ����
        inventory = new List<string>(); // ���� �ʱ�ȭ

        // Save ��ư Ŭ�� �� ���� ����
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveGame);
        }
        else
        {
            Debug.LogError("Save ��ư�� �������� �ʾҽ��ϴ�.");
        }

        // Exit ��ư Ŭ�� �� Ÿ��Ʋ ������ �̵�
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitToTitle);
        }
        else
        {
            Debug.LogError("Exit ��ư�� �������� �ʾҽ��ϴ�.");
        }

        // InputField ������ ����
        if (planetNameInputField != null)
        {
            planetNameInputField.onValueChanged.AddListener(SetPlanetName);
        }
        else
        {
            Debug.LogError("Planet Name InputField�� �������� �ʾҽ��ϴ�.");
        }
    }

    public void SetPlanetName(string name)
    {
        planetName = name;
        Debug.Log("SetPlanetName ȣ���: " + planetName);
    }

    public void SaveGame()
    {
        try
        {
            saveSystem.SaveGame(playerHP, inventory, planetName);  // planetName�� ����Ͽ� ����
            Debug.Log("������ ���������� ����Ǿ����ϴ�.");
        }
        catch (System.Exception ex)
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
        //SaveGame();  // ���� ����
        yield return new WaitForSeconds(1f); // ����� ��� �ð�

        // Ÿ��Ʋ ������ �̵�
        SceneManager.LoadScene("Title");
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " ������Ʈ�� �ı��Ǿ����ϴ�.");
    }
}