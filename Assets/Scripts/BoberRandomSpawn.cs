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

    public SO_Int crateSpawnTimer;
    public SO_Int boberSpawned;
    public SO_Int maxBoberAllowed;

    private void Start()
    {
        crateSpawnTimer.soInt = 10;
        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(crateSpawnTimer.soInt);
        if (boberSpawned.soInt != maxBoberAllowed.soInt)
        {
            randomX = Random.Range(leftCornerX.position.x,rightCornerX.position.x);
            randomY = Random.Range(cornerDown.position.y, cornerUp.position.y);
            new Vector3(randomX, randomY, 0);
            Instantiate(spawnCrate, new Vector3(randomX, randomY, 0), Quaternion.Euler(-270, -90, 90));
            yield return StartCoroutine(SpawnRandom());
        }
        else
        {
            yield return StartCoroutine(SpawnRandom());
        }

    }

}
