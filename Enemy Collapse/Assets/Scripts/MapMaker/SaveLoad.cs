using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveToFile(LevelData lvl)
    {
        string jsonString = JsonUtility.ToJson(lvl);
        File.WriteAllText("./Data/JsonLevels/" + lvl.Name + ".json", jsonString);
    }

    public static LevelData LoadFromFile(string name)
    {
        string fromFile = File.ReadAllText(name);
        LevelData fromJson = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));
        JsonUtility.FromJsonOverwrite(fromFile, fromJson);
        return fromJson;
    }

    public static List<LevelData> LoadAllLevels()
    {
        List<LevelData> levels = new List<LevelData>();
        string[] files = Directory.GetFiles("./Data/JsonLevels/");
        foreach (string filename in files)
        {
            levels.Add(LoadFromFile(filename));
        }
        return levels;
    }
}
