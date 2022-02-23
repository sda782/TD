using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    private int health = 100;
    private UIManager uIManager;
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    public void RemoveHealth(int damage)
    {
        health -= damage;
        uIManager.UpdateHealthUI(health);
        if (health <= 0) SceneManager.LoadScene("Menu");
    }
}
