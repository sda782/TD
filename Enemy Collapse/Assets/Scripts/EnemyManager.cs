using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private int amount;
    private int numberofenemies = 10;
    public void SpawnEnemies()
    {
        amount = 0;
        Level.NumberOfEnemies = numberofenemies;
        InvokeRepeating("spawnEnemy", 0.1f, 0.3f);
    }

    private void spawnEnemy()
    {
        if (amount == numberofenemies - 1) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemies[Random.Range(0, enemies.Length)]);
    }
}
