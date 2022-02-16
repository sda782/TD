using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static LevelData levelData;
    private static int lvl_index;
    [SerializeField]
    private LevelData[] lvl;
    void Awake()
    {
        levelData = lvl[0];
    }

    public void ChangeLevel()
    {
        lvl_index = lvl_index == 3 ? 0 : lvl_index++;
        levelData = lvl[lvl_index];
        SceneManager.LoadScene("SampleScene");
    }
}
