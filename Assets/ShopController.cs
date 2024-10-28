using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
   [SerializeField] SO_Int PlayerMoney;
   
   [Header("Spawn Upgrade")]
   [SerializeField] SO_Int crateSpawnTimer;
   public int upgradeLimit;
   int spawnbUpgradeAlready;
   [SerializeField] int moneyNeeded;
   [SerializeField] TextMeshProUGUI buttonTextSpawn;
   
   void Start()
   {
      buttonTextSpawn.text = moneyNeeded.ToString();
   }



   public void UpgradeBoberSpawn()
   {
      
      if (spawnbUpgradeAlready != upgradeLimit && PlayerMoney.soInt > moneyNeeded)
      {
         moneyNeeded = moneyNeeded * 2;
         spawnbUpgradeAlready += 1;
         crateSpawnTimer.soInt -= 1;
      }
   }
}
