using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public float spawnInterval = 1f;
    public GameObject waterDropletPrefab;
    public Transform spawnPoint;

    // Use this for initialization
    void Start()
    {
        ChangeInterval(spawnInterval);
    }

    private void SpawnWaterDroplet()
    {
        Instantiate(waterDropletPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void ChangeInterval(float newInterval)
    {
        CancelInvoke();
        spawnInterval = newInterval;
        InvokeRepeating("SpawnWaterDroplet", 0.1f, spawnInterval);
    }
}

