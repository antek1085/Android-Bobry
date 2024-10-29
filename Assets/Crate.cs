using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [SerializeField] GameObject boberToSpawn;
    private AudioSource audioSource;


    public void CreateOpen()
    {
        Instantiate(boberToSpawn, this.transform.position, Quaternion.Euler(-270, -90, 90));
        Destroy(this.gameObject);
    }
}
