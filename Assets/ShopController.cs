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

   [Header("More Bober Upgrade")]
   [SerializeField] SO_Int maxBoberAllowed;
   [SerializeField] TextMeshProUGUI buttonTextMoreBobers;
   [SerializeField] int moneyNeededMoreBober;
   int boberSpaceUpgradeAlready;
   
   
   
   void Start()
   {
      buttonTextSpawn.text = moneyNeeded.ToString();
   }



   public void UpgradeBoberSpawn()
   {
      
      if (spawnbUpgradeAlready != upgradeLimit && PlayerMoney.soInt > moneyNeeded)
      {
         PlayerMoney.soInt -= moneyNeeded;
         moneyNeeded = moneyNeeded * 2;
         spawnbUpgradeAlready += 1;
         crateSpawnTimer.soInt -= 1;
      }
   }

   public void UpgradeBoberSpace()
   {
      if (PlayerMoney.soInt > moneyNeededMoreBober)
      {
         PlayerMoney.soInt -= moneyNeededMoreBober;
         maxBoberAllowed.soInt += 5;
         moneyNeededMoreBober *= 2;
      }
   }
}
