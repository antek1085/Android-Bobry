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

    [Header("Sound Settings")]
    [SerializeField] private AudioClip upgradeSound; // Pole na dŸwiêk przy przycisku
    private AudioSource audioSource;

    void Start()
    {
        buttonTextSpawn.text = moneyNeeded.ToString();

        // Dodaj AudioSource do obiektu, jeœli jeszcze go nie ma
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = upgradeSound;
    }

    public void UpgradeBoberSpawn()
    {
        if (spawnbUpgradeAlready != upgradeLimit && PlayerMoney.soInt > moneyNeeded)
        {
            // Ulepszenie
            moneyNeeded *= 2;
            spawnbUpgradeAlready += 1;
            crateSpawnTimer.soInt -= 1;

            // Zaktualizuj tekst przycisku
            buttonTextSpawn.text = moneyNeeded.ToString();

            // Odtwórz dŸwiêk
            if (audioSource && upgradeSound)
            {
                audioSource.PlayOneShot(upgradeSound);
            }
        }
    }
}
