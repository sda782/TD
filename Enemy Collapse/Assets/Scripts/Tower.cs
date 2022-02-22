using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    private static int health = 100;
    public static void RemoveHealth(int damage)
    {
        health -= damage;
        if (health <= 0) SceneManager.LoadScene("Menu");
    }
}
