using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoint;
    [SerializeField] Manager manager;
    [SerializeField] Buttons buttons;

    private int wavesToSpawn;
    private int enemiesToSpawn;
    private int spawnInterval;
    private float timeBetweenWaves=7f;
    private int currentWave = 0;
    private int currentLevel;
    private bool nextLevel = true;
    private int lastWaveCount;

    public static bool isLevelDone = false;

    private void Start()
    {
        UpdateAndSpawn();
    }

    private void Update()
    {
        if (currentWave >= wavesToSpawn && EnemyList.enemies.Count == 0 && nextLevel)
        {
            Time.timeScale = 0;
            buttons.endLevelMenu.SetActive(true);
            manager.Stars();
        }
    }

    public void Spawn()
    {
        isLevelDone = true;
        nextLevel = false;
        currentLevel++;
        currentWave = 0;
        UpdateAndSpawn();
    }

    public int LastWaveCount(int currentLevel)
    {
        if (currentLevel==0)
        {
            return 8;
        }
        else if (currentLevel==1)
        {
            return 10;
        }
        else if (currentLevel == 2)
        {
            return 12;
        }
        else if (currentLevel == 3)
        {
            return 15;
        }
        else if (currentLevel == 4||currentLevel==5)
        {
            return 20;
        }
        else if (currentLevel == 6)
        {
            return 25;
        }
        else if (currentLevel == 7)
        {
            return 30;
        }
        else if (currentLevel == 8)
        {
            return 35;
        }
        else if (currentLevel == 9)
        {
            return 50;
        }
        else
        {
            return 0;
        }
    }

    IEnumerator SpawnWavesCoroutine()
    {
        while (currentWave < wavesToSpawn)
        {
            yield return StartCoroutine(SpawnWaveCoroutine());
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnWaveCoroutine()
    {
        int lastWavesCount = Mathf.Min(3, wavesToSpawn - currentWave);
        int additionalEnemies = 0;

        if (currentWave >= wavesToSpawn - lastWavesCount)
        {
            additionalEnemies = LastWaveCount(currentLevel); // Adjust this formula as needed
        }

        for (int i = 0; i < enemiesToSpawn + additionalEnemies; i++)
        {
            int enemyIndex = (currentLevel > 5 && i % 2 == 0) ? 1 : 0;
            SpawnSingleEnemy(enemyIndex);
            yield return new WaitForSeconds(spawnInterval);
        }

        currentWave++;
    }

    public void UpdateAndSpawn()
    {
        SetWavesToSpawn();
        StartCoroutine(SpawnWavesCoroutine());
        nextLevel = true;
    }

    void SetWavesToSpawn()
    {
        if (currentLevel == 0)
        {
            wavesToSpawn = 5;
            enemiesToSpawn = 5;
            spawnInterval = 1;
        }
        else if (currentLevel == 1)
        {
            wavesToSpawn = 8;
            enemiesToSpawn = 8;
            spawnInterval = 1;
        }
        else if (currentLevel == 2)
        {
            wavesToSpawn = 10;
            enemiesToSpawn = 10;
            spawnInterval = 1;
        }
        else if (currentLevel == 3)
        {
            wavesToSpawn = 12;
            enemiesToSpawn = 12;
            spawnInterval = 1;
        }
        else if (currentLevel == 4)
        {
            wavesToSpawn = 15;
            enemiesToSpawn = 15;
            spawnInterval = 1;
        }
        else if (currentLevel == 5 || currentLevel == 6 || currentLevel == 7)
        {
            wavesToSpawn = 15;
            enemiesToSpawn = 15;
            spawnInterval = 1;
        }
        else if (currentLevel == 8 || currentLevel == 9 || currentLevel == 10)
        {
            wavesToSpawn = 20;
            enemiesToSpawn = 20;
            spawnInterval = 1;
        }
    }

    void SpawnSingleEnemy(int enemyIndex)
    {
        EnemyList.enemies.Add(Instantiate(enemyPrefab[enemyIndex], spawnPoint[currentLevel].position, spawnPoint[currentLevel].rotation).gameObject);
    }
}
