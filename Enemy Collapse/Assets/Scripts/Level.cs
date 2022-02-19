using UnityEngine;

public class Level : MonoBehaviour
{
    public static LevelData levelData;
    void Awake()
    {
        levelData = MenuData.Level;
    }

}
