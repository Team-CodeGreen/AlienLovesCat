using System.IO;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public void SaveGame(GameState state, string filename = "savegame.json")
    {
        string json = JsonUtility.ToJson(state);
        string path = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllText(path, json);
        Debug.Log("Game saved successfully at " + path);
    }
}
