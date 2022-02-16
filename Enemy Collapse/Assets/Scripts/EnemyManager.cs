using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private int amount;
    private int numberofenemies = 10;
    public void SpawnEnemies()
    {
        amount = 0;
        InvokeRepeating("spawnEnemies", 0.1f, 0.3f);
    }

    private void spawnEnemies()
    {
        if (amount == numberofenemies - 1) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemy);
        e.transform.SetParent(GameObject.Find("EnemyManager").transform);
    }
}
