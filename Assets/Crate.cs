using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] GameObject boberToSpawn;
    private AudioSource audioSource;


    public void CreateOpen()
    {
        Instantiate(boberToSpawn, this.transform.position, Quaternion.Euler(0, -0, 0));
        Destroy(this.gameObject);
    }
}
