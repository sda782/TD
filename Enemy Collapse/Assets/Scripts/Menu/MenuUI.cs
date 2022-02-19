using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    private List<LevelData> levels;
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private Button button;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        LevelData[] levelsArr = (LevelData[])Resources.LoadAll<LevelData>("Levels");
        levels = levelsArr.ToList();
        levels.AddRange(SaveLoad.LoadAllLevels());
        int yH = -130;
        for (int i = 0; i < levels.Count; i++)
        {
            int x = i;
            Button g = Instantiate(button);
            g.GetComponentInChildren<Text>().text = levels[i].Name;
            g.transform.SetParent(content.transform);
            g.onClick.AddListener(() => SetLvlIndex(x));
            g.transform.position = content.position + new Vector3(315, yH, 0);
            yH -= 90;
        }

    }
    public void SetLvlIndex(int index)
    {
        MenuData.Level = levels[index];
        SceneManager.LoadScene("SampleScene");
    }

    public void SendToMapMaker()
    {
        SceneManager.LoadScene("MapMaker");
    }
}
