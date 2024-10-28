using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoberRandomSpawn : MonoBehaviour
{
    [SerializeField] private Transform leftCornerX, rightCornerX;
    [SerializeField] private Transform cornerUp, cornerDown;
    [SerializeField] private GameObject spawnCrate;

    [SerializeField] private AudioClip spawnSound; // Dodaj pole AudioClip do przypisania dŸwiêku.
    private AudioSource audioSource; // Zmienna dla AudioSource.

    public SO_Int crateSpawnTimer;

    private float randomX, randomY;

    private void Start()
    {
        crateSpawnTimer.soInt = 10;
        audioSource = gameObject.AddComponent<AudioSource>(); // Dodanie komponentu AudioSource.
        audioSource.clip = spawnSound; // Przypisz dŸwiêk do AudioSource.

        StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(crateSpawnTimer.soInt);
        randomX = Random.Range(leftCornerX.position.x, rightCornerX.position.x);
        randomY = Random.Range(cornerDown.position.y, cornerUp.position.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(spawnCrate, spawnPosition, Quaternion.Euler(-270, -90, 90));

        // Odtwórz dŸwiêk przy ka¿dym spawnie
        if (audioSource && spawnSound)
        {
            audioSource.PlayOneShot(spawnSound);
        }

        yield return StartCoroutine(SpawnRandom());
    }
}

