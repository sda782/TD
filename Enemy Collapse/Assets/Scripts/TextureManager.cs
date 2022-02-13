using System.Collections;
using System.Collections.Generic;
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
}
