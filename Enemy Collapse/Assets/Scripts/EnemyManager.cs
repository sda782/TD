using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private int amount;
    private int numberofenemies = 10;
    public static EnemySO GetRandomEnemyType { get => enemySOs[Random.Range(0, enemySOs.Length)]; }
    private static EnemySO[] enemySOs;
    public void SpawnEnemies()
    {
        if (enemySOs == null) enemySOs = (EnemySO[])Resources.LoadAll<EnemySO>("Enemies");
        amount = 0;
        InvokeRepeating("spawnEnemy", 0.1f, 0.3f);
    }

    private void spawnEnemy()
    {
        if (amount == numberofenemies - 1) CancelInvoke();
        amount++;
        GameObject e = Instantiate(enemies[0]);
        //e.GetComponent<EnemyData>().SetType(GetRandomEnemyType);
    }
}
