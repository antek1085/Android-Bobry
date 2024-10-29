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
   [SerializeField] TextMeshProUGUI levelTextSpawn;

   [Header("More Bober Upgrade")]
   [SerializeField] SO_Int maxBoberAllowed;
   [SerializeField] TextMeshProUGUI buttonTextMoreBobers;
   [SerializeField] int moneyNeededMoreBober;
   int boberSpaceUpgradeAlready;
   [SerializeField] TextMeshProUGUI levelTextSpace;



   [Header("Sound Settings")]
    [SerializeField] private AudioClip upgradeSound; // Pole na d�wi�k przy przycisku
    private AudioSource audioSource;

     void Start()
    {
        buttonTextSpawn.text = moneyNeeded.ToString();
        levelTextSpawn.text = "Level: " + spawnbUpgradeAlready + "/" + upgradeLimit;
        buttonTextMoreBobers.text = moneyNeededMoreBober.ToString();
        levelTextSpace.text = "Level: " + boberSpaceUpgradeAlready;

        // Dodaj AudioSource do obiektu, je�li jeszcze go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = upgradeSound;  
    }

     public void UpgradeBoberSpawn()
   {
    
      if (spawnbUpgradeAlready != upgradeLimit && PlayerMoney.soInt > moneyNeeded) 
      {
         PlayerMoney.soInt -= moneyNeeded;
         moneyNeeded = moneyNeeded * 2;
         spawnbUpgradeAlready += 1;
         crateSpawnTimer.soInt -= 1;
         buttonTextSpawn.text = moneyNeeded.ToString();
         levelTextSpawn.text = "Level: " + spawnbUpgradeAlready + "/" + upgradeLimit;
          if (audioSource && upgradeSound)
          { 
              audioSource.PlayOneShot(upgradeSound);
          }
      }
   }

   public void UpgradeBoberSpace()
   {
        if(PlayerMoney.soInt > moneyNeededMoreBober)
      { 
         PlayerMoney.soInt -= moneyNeededMoreBober;
         maxBoberAllowed.soInt += 5;
         moneyNeededMoreBober *= 10;
         buttonTextMoreBobers.text = moneyNeededMoreBober.ToString();
         levelTextSpace.text = "Level: " + boberSpaceUpgradeAlready;
      }
   }
   
}
