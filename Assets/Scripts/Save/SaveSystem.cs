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
        // Singleton 패턴: 인스턴스가 없으면 현재 오브젝트를 할당하고 파괴되지 않도록 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 씬 전환 시에도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);  // 기존 인스턴스가 있으면 새 오브젝트를 파괴
            return;  // 아래 코드를 실행하지 않도록 return
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
        Debug.Log("저장할 행성 이름: " + planetName); // 저장할 행성 이름 로그
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
        return "저장된 게임이 없습니다.";
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