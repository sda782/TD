using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private Camera cam;
    private GameObject selectedObj = null;
    private GameObject lastSelected = null;
    [SerializeField]
    private GridController gridController;
    [SerializeField]
    public UnityEvent StartGame;

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
                Debug.Log(hit.transform.position);
                lastSelected = selectedObj != null ? selectedObj : null;
                selectedObj = hit.transform.gameObject;
                ChangeSprite();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame?.Invoke();
        }
    }

    private void ChangeSprite()
    {
        Renderer srend = selectedObj.GetComponent<Renderer>();
        srend.material.mainTexture = gridController.Textures[2];

        if (lastSelected == null) return;
        Renderer lrend = lastSelected.GetComponent<Renderer>();
        lrend.material.mainTexture = gridController.Textures[1];
    }
}
