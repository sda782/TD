using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    public UnityEvent StartGame;
    [SerializeField]
    public UnityEvent Shoot;
    [SerializeField]
    public UnityEvent<Vector3> PlaceTurret;
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
            leftClickHandler();

        }
        if (Input.GetMouseButtonDown(1))
        {
            rightClickHandler();

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartGame?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            hideMenu();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    private void rightClickHandler()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Placeable")
            {
                placeObj(hit);
            }
        }
    }

    private void leftClickHandler()
    {
        Shoot?.Invoke();
    }

    private void placeObj(RaycastHit hit)
    {
        PlaceTurret?.Invoke(hit.point);
    }

    private void hideMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

}
