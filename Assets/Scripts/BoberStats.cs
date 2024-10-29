using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;

    public GameObject nextBober;

    public int boberLevel;
    [SerializeField] SO_Int boberSpawned;

    // Update is called once per frame
    void Start()
    {
        boberSpawned.soInt += 1;
        EventSystem.current.MoneyGainChange(moneyGain);
    }

    void OnDestroy()
    {
        boberSpawned.soInt -= 1;
    }

}
