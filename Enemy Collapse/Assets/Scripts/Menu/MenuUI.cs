using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void SetLvlIndex(int index)
    {
        MenuData.LevelIndex = index;
        SceneManager.LoadScene("SampleScene");
    }
}
