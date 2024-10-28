using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;
    public GameObject nextBober;
    public int boberLevel;

    [SerializeField] private AudioClip startSound; // Dodaj d�wi�k na starcie
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Dodaj komponent AudioSource i przypisz d�wi�k
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = startSound;

        // Odtw�rz d�wi�k, je�li jest przypisany
        if (audioSource && startSound)
        {
            audioSource.PlayOneShot(startSound);
        }

        // Wywo�aj event MoneyGainChange
        EventSystem.current.MoneyGainChange(moneyGain);
    }
}

