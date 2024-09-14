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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
          //  gameObject.SetActive(false);
            return;
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

    public void SaveGame(string planetName, string sceneName)
    {

        // 기존 저장된 데이터 가져오기 (만약 존재한다면)
        SaveData existingData = null;
        if (File.Exists(savePath))
        {
            string existingJson = File.ReadAllText(savePath);
            existingData = JsonUtility.FromJson<SaveData>(existingJson);
        }

        // 행성 이름이 기본값일 경우 기존 데이터에서 행성 이름 유지
        string finalPlanetName = (planetName == "DefaultPlanetName" && existingData != null) ? existingData.planetName : planetName;

        Debug.Log("Saving planet name: " + finalPlanetName); // 디버그 로그 추가
        SaveData saveData = new SaveData
        {
            saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            sceneName = sceneName,
            planetName = finalPlanetName // 행성 이름 저장
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Saved JSON: " + json); // JSON 데이터 디버그 로그 추가
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
    public string saveTime;
    public string sceneName;
    public string planetName;
}