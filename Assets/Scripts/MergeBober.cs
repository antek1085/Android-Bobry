using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeBober : MonoBehaviour
{
    public string boberTag;

    private GameObject boberToSpawn;

    public bool isHolded;

    private void Start()
    {
        isHolded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boberTag && isHolded == true)
        {
            print("TEst");
            boberToSpawn = other.GetComponent<BoberStats>().nextBober;
            Destroy(other.gameObject);
            Instantiate(boberToSpawn);  
            Destroy(this);
        }
    }
}
