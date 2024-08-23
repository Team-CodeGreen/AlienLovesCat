using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    private static SaveSystem instance;
    private string savePath;
    void Awake()
    {
        // 싱글턴 패턴을 사용하여 SaveSystem 인스턴스를 유지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 새로 생성된 오브젝트는 파괴
        }
    }
    void Start()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Save path: " + savePath);
        
        // 저장된 시간 출력
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

    public void SaveGame(int playerHP, List<string> inventory)
    {
        SaveData saveData = new SaveData
        {
            hp = playerHP,
            inventoryItems = inventory,
            saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            sceneName = SceneManager.GetActiveScene().name  // 현재 씬 이름 저장
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);

        Debug.Log("게임이 저장되었습니다.");
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
        else
        {
            return "저장된 게임이 없습니다.";
        }
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
    public string sceneName;  // 저장된 씬 이름 추가
}