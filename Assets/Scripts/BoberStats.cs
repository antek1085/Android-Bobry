using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoberStats : MonoBehaviour
{
    public int moneyGain;
    public GameObject nextBober;
    public int boberLevel;
    [SerializeField] SO_Int boberSpawned;
    [SerializeField] Animator animator;

    [SerializeField] private AudioClip startSound; // Dodaj d�wi�k na starcie
    private AudioSource audioSource;
    [SerializeField] GameObject poop;

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

        StartCoroutine(BoberDance());
    }

    IEnumerator BoberDance()
    {
        yield return new WaitForSeconds(8);
        Instantiate(poop, transform.position, Quaternion.identity);
        this.gameObject.transform.DOJump(this.gameObject.transform.position, 1f, 1, 0.5f, true);
        yield return StartCoroutine(BoberDance());
    }

    void OnDestroy()
    {
        boberSpawned.soInt -= 1;
    }

}

