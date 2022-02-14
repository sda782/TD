
using UnityEngine;

public class TextureManager : MonoBehaviour
{
    [SerializeField]
    private GridController gridController;

    public void SetTexture(GameObject gameObject, int index)
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.mainTexture = gridController.Textures[index];
    }
    public GameObject SetPathTexture(GameObject obj, Vector2 dir)
    {
        int index = gridController.Grid.FindIndex(g => g == obj);
        GameObject g = null;
        switch (dir.normalized)
        {
            case Vector2 v when v.Equals(Vector2.right):
                g = gridController.Grid[index + (int)Level.levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.up):
                g = gridController.Grid[++index];
                break;
            case Vector2 v when v.Equals(Vector2.left):
                g = gridController.Grid[index - (int)Level.levelData.WorldSize.x];
                break;
            case Vector2 v when v.Equals(Vector2.down):
                g = gridController.Grid[--index];
                break;
        }
        if (g == null) return null;
        SetTexture(g, 1);
        return g;
    }
}
