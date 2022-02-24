using UnityEditor;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static LevelSO levelData;
    private static int numberofenemies;
    public static int NumberOfEnemies
    {
        get => numberofenemies;
        set
        {
            numberofenemies = value;
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateEnemyLeft(numberofenemies);
        }
    }
    void Awake()
    {
        levelData = MenuData.Level;
    }

}
