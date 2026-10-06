using System.IO;

using UnityEngine;

public class SaveSystem
{

    string filePath = Path.Combine(Application.persistentDataPath, "playerdata.json");
    public void SavePlayerData(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, json);

        Debug.Log($"File successfully created at: {filePath}");
        Debug.Log($"{json}");

    }

    public PlayerData LoadPlayerData()
    {
        string data = File.ReadAllText(filePath);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(data);
        Debug.Log($"Data loaded: {data}");
        return playerData;
    }
}
