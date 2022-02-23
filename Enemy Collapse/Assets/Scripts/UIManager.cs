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
    public void UpdateHealthUI(int hp)
    {
        health.text = "TOWER HP: " + hp;
    }

    public void UpdateWaveInfo(string infostring)
    {
        waveinfo.text = infostring;
    }
}
