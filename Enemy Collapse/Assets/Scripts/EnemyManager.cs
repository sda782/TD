using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private int amount;
    private int numberofenemies = 10;
    public static EnemySO GetRandomEnemyType { get => enemySOs[Random.Range(0, enemySOs.Length)]; }
    private static EnemySO[] enemySOs;
    public void SpawnEnemies()
    {
        amount = 0;
        InvokeRepeating("spawnEnemies", 0.1f, 0.3f);
        if (enemySOs == null) enemySOs = (EnemySO[])Resources.LoadAll<EnemySO>("Enemies");
    }

    private void spawnEnemies()
    {
        if (amount == numberofenemies - 1) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemy);
    }
}
