using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static LevelData levelData;
    [SerializeField]
    private LevelData[] lvl;
    void Awake()
    {
        levelData = lvl[MenuData.LevelIndex];
    }

}
