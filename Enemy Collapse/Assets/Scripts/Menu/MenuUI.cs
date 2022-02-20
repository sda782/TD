using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    private List<LevelSO> levels;
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private Button button;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        LevelSO[] levelsArr = (LevelSO[])Resources.LoadAll<LevelSO>("Levels");
        levels = levelsArr.ToList();
        levels.AddRange(SaveLoad.LoadAllLevels());
        for (int i = 0; i < levels.Count; i++)
        {
            int x = i;
            Button g = Instantiate(button);
            g.GetComponentInChildren<Text>().text = levels[i].Name;
            g.transform.SetParent(content.transform);
            g.transform.localScale = Vector3.one;
            g.onClick.AddListener(() => SetLvlIndex(x));
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

    public void ShowLevelFolder()
    {
        SaveLoad.ShowLevelFolder();
    }
}
