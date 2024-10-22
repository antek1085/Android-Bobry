using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeBober : MonoBehaviour
{
    public string boberTag;

    private GameObject boberToSpawn;
    private int boberLevel;

    public bool isHolded;

    private void Start()
    {
        boberToSpawn = GetComponent<BoberStats>().nextBober;
        isHolded = false;
        boberLevel = GetComponent<BoberStats>().boberLevel;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == boberTag && isHolded == true)
        {
            Debug.Log(other.GetComponent<BoberStats>().boberLevel + " Level");
            
            if (other.GetComponent<BoberStats>().boberLevel == boberLevel)
            {
                Destroy(other.gameObject);
                Instantiate(boberToSpawn,transform.position,transform.rotation);  //Spawn nowego mobka
                Destroy(gameObject);  
            }
        }
    }
}
