using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;

    public GameObject nextBober;

    public int boberLevel;

    // Update is called once per frame
    void Start()
    {
        EventSystem.current.MoneyGainChange(moneyGain);
    }
    
}
