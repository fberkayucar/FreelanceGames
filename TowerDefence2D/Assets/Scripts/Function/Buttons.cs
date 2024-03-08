using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject tower;
    public GameObject tower2;

    [SerializeField] TowerPlace towerPlace;
    [SerializeField] Manager manager;
    [SerializeField] GameObject towerPalette;
    [SerializeField] WaveSpawner waveSpawner;
    [SerializeField] LevelController levelController;
    public GameObject endLevelMenu;


    private float tower1Price = 50f;
    private float tower2Price = 100f;

    public void SetTowerPlaceReference(TowerPlace towerRef)
    {
        towerPlace = towerRef;
    }

    public void NextLevel()
    {
        foreach (var enemies in EnemyList.enemies)
        {
            Destroy(enemies);
        }
        waveSpawner.Spawn();
        levelController.isLevelDone();
        Time.timeScale = 1;
        endLevelMenu.SetActive(false);
        manager.DeactiveStars();
        manager.RestartVariables();
    }


    public void CreateTower()
    {
        Debug.Log("Tower created");
        towerPlace.SetAllTowerPlacesWhite();
        if (manager.money>=tower1Price)
        {
            GameObject newTower = Instantiate(tower, new Vector3(manager.coordinate.position.x, manager.coordinate.position.y, 0), Quaternion.identity);
            TowerList.towers.Add(newTower);
            towerPalette.SetActive(false);
            manager.place.SetActive(false);
            manager.isTowerPlaced = true;
            manager.place = null;
            manager.money -= 50f;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void CreateTower2()
    {
        towerPlace.SetAllTowerPlacesWhite();
        if (manager.money>=tower2Price)
        {
            GameObject newTower = Instantiate(tower2, new Vector3(manager.coordinate.position.x, manager.coordinate.position.y, 0), Quaternion.identity);
            TowerList.towers.Add(newTower);
            towerPalette.SetActive(false);
            manager.place.SetActive(false);
            manager.isTowerPlaced = true;
            manager.place = null;
            manager.money -= 100f;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

}
