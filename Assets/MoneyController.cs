using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private int moneyGain;
    private float time;
    [SerializeField] SO_Int playerMoney;


    System.DateTime leftGameData = new DateTime();
    DateTime joinGameAgain = new DateTime();
    int timePassed;
    [SerializeField] TextMeshProUGUI showMoney;
    [SerializeField] TextMeshProUGUI moneyGainText;
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
        showMoney.text = playerMoney.soInt.ToString();
        moneyGainText.text = moneyGain.ToString() + "/s";
    }

    // Update is called once per frame
    void onMoneyGanChange(int money)
    {
        moneyGain += money;
    }
    

    /*void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus == true)
        {
            if (joinGameAgain != leftGameData)
            {
                timePassed = joinGameAgain.Day * 1440 + joinGameAgain.Hour * 60 + joinGameAgain.Minute -
                             (leftGameData.Day * 1440 + leftGameData.Hour * 60 + joinGameAgain.Minute);
                playerMoney.soInt += moneyGain * 60 * timePassed;
                Debug.Log(timePassed + "  TEST");
            }
            joinGameAgain = DateTime.Now;
        }
        else
        {
            leftGameData = DateTime.Now;
            Debug.Log("Pouse Starts");
        }
            
    }*/
}
