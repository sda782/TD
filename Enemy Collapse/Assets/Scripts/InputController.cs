using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class InputController : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private GridController gridController;
    [SerializeField]
    public UnityEvent StartGame;
    [SerializeField]
    public UnityEvent<GameObject> HitEnemy;
    [SerializeField]
    private GameObject weaponStart;
    [SerializeField]
    private GameObject menu;

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
                switch (hit.transform.tag)
                {
                    case "Enemy":
                        handleEnemy(hit);
                        break;
                    default:
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartGame?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            hideMenu();
        }
    }

    private void hideMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    private void handleEnemy(RaycastHit hit)
    {
        HitEnemy?.Invoke(hit.transform.parent.gameObject);
        //Destroy(hit.transform.parent.gameObject);
    }
}
