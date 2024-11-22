using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Ranges")]
    public float xRange;
    public float yRange;
    public float zRange;

    [Header("Prefabs")]
    public GameObject enemyPrefab;

    [Header("SpawnPoints")]
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;

    [Header("Ints")]
    public int enemyCount;
    public int waveNumber = 1;

    [Header("Scripts")]
    public PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnEnemyWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomPos(), enemyPrefab.transform.rotation);
        }
    }
    public Vector3 RandomPos()
    {
        float xPos = Random.Range(-xRange, xRange);
        float yPos = Random.Range(-yRange, yRange);
        float zPos = Random.Range(-zRange, zRange);
        Vector3 RandomPosition = new Vector3(xPos, yPos, zPos);
        return RandomPosition;
    }
    public void SpawnPrefab()
    {
        Instantiate(enemyPrefab, RandomPos(), transform.rotation);
    }
}
