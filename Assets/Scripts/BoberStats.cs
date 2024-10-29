using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;
    public GameObject nextBober;
    public int boberLevel;
    [SerializeField] SO_Int boberSpawned;

    [SerializeField] private AudioClip startSound; // Dodaj d�wi�k na starcie
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = startSound;
        boberSpawned.soInt += 1;
        EventSystem.current.MoneyGainChange(moneyGain);

        if(audioSource && startSound)
        {
            audioSource.PlayOneShot(startSound);
        }
    }

    void OnDestroy()
    {
        boberSpawned.soInt -= 1;
    }

}

