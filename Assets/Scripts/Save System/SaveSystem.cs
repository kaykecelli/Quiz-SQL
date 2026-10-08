using System.IO;

using UnityEngine;

public static class SaveSystem
{
    public static void SaveData<TData>(TData Data, string fileName)
    {
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(GetFilePath(fileName), json);

        Debug.Log($"File successfully created at: {GetFilePath(fileName)}");
        Debug.Log($"{json}");

    }

    public static TData LoadData<TData>(string fileName)
    {
        if (File.Exists(GetFilePath(fileName)))
        {
            string data = File.ReadAllText(GetFilePath(fileName));
            TData returnData = JsonUtility.FromJson<TData>(data);
            Debug.Log($"Data loaded: {data}");
            return returnData;
        }
        Debug.LogWarning($"No Save found.");
        return default;
    }
    public static void DeleteData(string fileName)
    {
        if (File.Exists(GetFilePath(fileName)))
        {
            File.Delete(GetFilePath(fileName));
            Debug.Log($"File deleted at: {GetFilePath(fileName)}");
        }
        else
        {
            Debug.LogWarning($"No file found at: {GetFilePath(fileName)}");
        }
    }

    public static bool DataExists(string fileName)
    {
        return File.Exists(GetFilePath(fileName));
    }

    private static string GetFilePath(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName);
    }
}
