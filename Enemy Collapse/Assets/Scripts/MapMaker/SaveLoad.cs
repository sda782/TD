using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveToFile(LevelSO lvl)
    {
        string jsonString = JsonUtility.ToJson(lvl);
        File.WriteAllText("./Data/JsonLevels/" + lvl.Name + ".json", jsonString);
    }

    public static LevelSO LoadFromFile(string name)
    {
        string fromFile = File.ReadAllText(name);
        LevelSO fromJson = (LevelSO)ScriptableObject.CreateInstance(typeof(LevelSO));
        JsonUtility.FromJsonOverwrite(fromFile, fromJson);
        return fromJson;
    }

    public static List<LevelSO> LoadAllLevels()
    {
        CheckFolders();
        List<LevelSO> levels = new List<LevelSO>();
        string[] files = Directory.GetFiles("./Data/JsonLevels/");
        foreach (string filename in files)
        {
            levels.Add(LoadFromFile(filename));
        }
        return levels;
    }
    public static void ShowLevelFolder()
    {
        if (Directory.Exists(Path.GetFullPath("./Data/JsonLevels/")))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetFullPath("./Data/JsonLevels/"),
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
    }
    public static void CheckFolders()
    {
        if (!Directory.Exists(Path.GetFullPath("./Data")))
        {
            DirectoryInfo di = Directory.CreateDirectory(Path.GetFullPath("./Data"));
        }
        if (!Directory.Exists(Path.GetFullPath("./Data/JsonLevels")))
        {
            DirectoryInfo di = Directory.CreateDirectory(Path.GetFullPath("./Data/JsonLevels"));
        }
    }
}
