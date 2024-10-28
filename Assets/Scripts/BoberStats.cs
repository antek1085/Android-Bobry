using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;
    public GameObject nextBober;
    public int boberLevel;

    [SerializeField] private AudioClip startSound; // Dodaj dŸwiêk na starcie
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Dodaj komponent AudioSource i przypisz dŸwiêk
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = startSound;

        // Odtwórz dŸwiêk, jeœli jest przypisany
        if (audioSource && startSound)
        {
            audioSource.PlayOneShot(startSound);
        }

        // Wywo³aj event MoneyGainChange
        EventSystem.current.MoneyGainChange(moneyGain);
    }
}

