using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoberRandomSpawn : MonoBehaviour
{
    [SerializeField] private Transform leftCornerX, rightCornerX;
    [SerializeField] private Transform cornerUp, cornerDown;

    private float randomX,randomY;

    [SerializeField] private GameObject spawnCrate;

    public int crateSpawnTimer;

    private void Start()
    {
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(crateSpawnTimer);
        randomX = Random.Range(leftCornerX.position.x,rightCornerX.position.x);
        randomY = Random.Range(cornerDown.position.y, cornerUp.position.y);
        new Vector3(randomX, randomY, 0);
        Instantiate(spawnCrate, new Vector3(randomX, randomY, 0), Quaternion.Euler(-270, -90, 90));
        yield return StartCoroutine(SpawnRandom());
    }

}
