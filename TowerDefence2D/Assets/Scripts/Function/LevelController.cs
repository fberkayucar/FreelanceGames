using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    [SerializeField] Manager manager;
    private GameObject currentLevelInstance;

    public int currentLevel;

    private void Start()
    {
        currentLevel = manager.levelIndex;
        SetLevel();
    }

    private void Update()
    {

    }

    public void isLevelDone()
    {
        if (WaveSpawner.isLevelDone)
        {
            WaveSpawner.isLevelDone = false;
            DisableCurrentLevel();
            currentLevel++;
            if (currentLevel < levels.Length)
            {
                SetLevel();
            }
            else
            {
                // Tüm seviyeler tamamlandýysa yapýlacak iþlemler
                Debug.Log("Oyun tamamlandý!");
            }
        }
    }

    public void SetLevel()
    {
        currentLevelInstance = Instantiate(levels[currentLevel], Vector3.zero, transform.rotation);
    }

    private void DisableCurrentLevel()
    {
        Destroy(currentLevelInstance);
        foreach (GameObject tower in TowerList.towers)
        {
            Destroy(tower);
        }
    }
}
