using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
     public static EventSystem current;

    void Awake()
    {
        current = this;
    }

    public event Action<int> onMoneyGainChange;

    public void MoneyGainChange(int money)
    {
        if (onMoneyGainChange != null)
        {
            onMoneyGainChange(money);
        }
    }
}
