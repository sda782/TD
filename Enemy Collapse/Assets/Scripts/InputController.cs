using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera cam;
    private GameObject selectedObj = null;
    private GameObject lastSelected = null;
    [SerializeField]
    private Sprite[] sprites;
    void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
                lastSelected = selectedObj != null ? selectedObj : null;
                selectedObj = hit.transform.gameObject;
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite()
    {
        Renderer srend = selectedObj.GetComponent<Renderer>();
        srend.material.mainTexture = sprites[1].texture;
        if (lastSelected == null) return;
        Renderer lrend = lastSelected.GetComponent<Renderer>();
        lrend.material.mainTexture = sprites[0].texture;
    }
}
