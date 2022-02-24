using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text health;
    [SerializeField]
    private Text waveinfo;
    [SerializeField]
    private Text coins;
    [SerializeField]
    private Text enemies;
    public void UpdateHealthUI(int hp)
    {
        health.text = "HP: " + hp;
    }

    public void UpdateEnemyLeft(int numberofenemies)
    {
        enemies.text = "LEFT: " + numberofenemies;
    }

    public void UpdateWaveInfo(string infostring)
    {
        waveinfo.text = infostring;
    }

    internal void UpdateCoins(int amount)
    {
        coins.text = "C: " + amount;
    }
}
