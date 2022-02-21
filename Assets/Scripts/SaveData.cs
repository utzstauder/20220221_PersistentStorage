using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string name;
    public int points;

    static string SaveDataSubPath => "Saves";
    static string SaveDataPath =>  Path.Combine(Application.persistentDataPath, SaveDataSubPath);

    public void Save(string filename)
    {
        if (Directory.Exists(SaveDataPath) == false)
        {
            Directory.CreateDirectory(SaveDataPath);
        }

        string filepath = Path.Combine(SaveDataPath, filename);

        string json = JsonUtility.ToJson(this);

        File.WriteAllText(filepath, json);

        Debug.Log($"Saved data to {filepath}");
    }

    public static SaveData Load(string filename)
    {
        if (Directory.Exists(SaveDataPath) == false)
        {
            Directory.CreateDirectory(SaveDataPath);
        }

        string filepath = Path.Combine(SaveDataPath, filename);

        if (File.Exists(filepath) == false)
        {
            Debug.LogError($"No save file found at {Path.Combine(SaveDataPath, filename)}");
            return new SaveData();
        }

        string json = File.ReadAllText(filepath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }
}
