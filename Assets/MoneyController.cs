using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int moneyGain;
    private float time;
    public int allMoney;
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
            allMoney += moneyGain;
        }
        Debug.Log("Money" + allMoney);
    }

    // Update is called once per frame
    void onMoneyGanChange(int money)
    {
        moneyGain += money;
    }
}
