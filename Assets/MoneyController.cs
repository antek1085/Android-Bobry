using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int moneyGain;
    private float time;
    [SerializeField] SO_Int playerMoney;
    private void Start()
    {
        EventSystem.current.onMoneyGainChange += onMoneyGanChange;
    }


    private void Update()
    {
        time += Time.deltaTime;

        if (time > 1)
        {
            time = 0;
            playerMoney.soInt += moneyGain;
        }
    }

    // Update is called once per frame
    void onMoneyGanChange(int money)
    {
        moneyGain += money;
    }
}
