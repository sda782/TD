using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private static int health;
    void Start()
    {
        health = 100;
    }
    public static void RemoveHealth(int damage)
    {
        health -= damage;
    }
}
