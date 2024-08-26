using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SaveGame(int hp, List<string> inventory)
    {
        PlayerData data = new PlayerData(hp, inventory);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);

        // 저장 시간 기록
        File.WriteAllText(savePath + ".time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }

    public PlayerData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        return null;
    }

    public bool HasSaveFile()
    {
        return File.Exists(savePath);
    }

    public DateTime GetLastSaveTime()
    {
        if (File.Exists(savePath + ".time"))
        {
            string timeString = File.ReadAllText(savePath + ".time");
            return DateTime.Parse(timeString);
        }
        return DateTime.MinValue;
    }
}

