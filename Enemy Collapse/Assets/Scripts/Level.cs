using UnityEngine;

public class Level : MonoBehaviour
{
    public static LevelSO levelData;
    void Awake()
    {
        levelData = MenuData.Level;
    }

}
