using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveToFile(LevelData lvl)
    {
        string jsonString = JsonUtility.ToJson(lvl);
        File.WriteAllText("./data/" + lvl.Name + ".json", jsonString);
    }

    public static LevelData LoadFromFile(string name)
    {
        string fromFile = File.ReadAllText("./data/" + name + ".json");
        LevelData fromJson = JsonUtility.FromJson<LevelData>(fromFile);
        return fromJson;
    }
}
