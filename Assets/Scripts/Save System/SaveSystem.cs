using System.IO;

using UnityEngine;

public static class SaveSystem
{
    public static void SaveData<TData>(TData Data, string fileName)
    {
        string json = JsonUtility.ToJson(Data);
        File.WriteAllText(GetFilePath(fileName + ".json"), json);

        Debug.Log($"File successfully created at: {GetFilePath(fileName)}");
        Debug.Log($"{json}");

    }

    public static TData LoadData<TData>(string fileName)
    {
        try
        {
            string data = File.ReadAllText(GetFilePath(fileName));
            TData returnData = JsonUtility.FromJson<TData>(data);
            Debug.Log($"Data loaded: {data}");
            return returnData;
        }
        catch(FileNotFoundException)
        {
            Debug.LogWarning($"No Save found at: {GetFilePath(fileName)}");
            return default;
        }
        catch
        {
            Debug.LogWarning($"Error loading data from: {GetFilePath(fileName)}");
            return default;
        }
    }
    public static void DeleteData(string fileName)
    {

        try
        {
            File.Delete(GetFilePath(fileName));
            Debug.Log($"File deleted at: {GetFilePath(fileName)}");
        }
        catch
        {
            Debug.LogWarning($"No Save found at: {GetFilePath(fileName)}");
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
