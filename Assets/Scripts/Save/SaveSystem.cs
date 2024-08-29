using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    private string savePath;

    private void Awake()
    {
        // Singleton ����: �ν��Ͻ��� ������ ���� ������Ʈ�� �Ҵ��ϰ� �ı����� �ʵ��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �� ��ȯ �ÿ��� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);  // ���� �ν��Ͻ��� ������ �� ������Ʈ�� �ı�
            return;  // �Ʒ� �ڵ带 �������� �ʵ��� return
        }
    }

    private void Start()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Save path: " + savePath);

        if (HasSaveFile())
        {
            string lastSavedTime = GetLastSaveTime();
            Debug.Log("Last Saved Time: " + lastSavedTime);
        }
        else
        {
            Debug.Log("No saved game found.");
        }
    }

    public void SaveGame(int playerHP, List<string> inventory, string planetName)
    {
        Debug.Log("������ �༺ �̸�: " + planetName); // ������ �༺ �̸� �α�
        SaveData saveData = new SaveData
        {
            hp = playerHP,
            inventoryItems = new List<string>(inventory),
            saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            sceneName = SceneManager.GetActiveScene().name,
            planetName = planetName
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
    }

    public bool HasSaveFile()
    {
        return File.Exists(savePath);
    }

    public string GetLastSaveTime()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            return saveData.saveTime;
        }
        return "����� ������ �����ϴ�.";
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return null;
    }

}

[System.Serializable]
public class SaveData
{
    public int hp;
    public List<string> inventoryItems;
    public string saveTime;
    public string sceneName;
    public string planetName;
}