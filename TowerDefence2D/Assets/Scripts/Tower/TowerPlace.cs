using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlace : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    Manager manager;
    GameObject towerPalette;
    Buttons buttons;

    private void Start()
    {
        buttons = GameObject.Find("Buttons").GetComponent<Buttons>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    private void OnMouseDown()
    {
        buttons.SetTowerPlaceReference(this);
        manager.SetTowerPlaceReference(this);
        if (gameObject.CompareTag("TowerPlace"))
        {
            manager.ActivateTowerPalette();
            SetAllTowerPlacesGreen();
            ColorChange();
            manager.place = gameObject;
            manager.coordinate = gameObject.transform;
        }
    }

    public void SetGreenColor()
    {
        GetComponent<SpriteRenderer>().material.color = Color.green;
    }
    void ColorChange()
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
    }
    void SetAllTowerPlacesGreen()
    {
        GameObject[] towerPlaces = GameObject.FindGameObjectsWithTag("TowerPlace");
        foreach (GameObject place in towerPlaces)
        {
            place.GetComponent<TowerPlace>().SetGreenColor();
        }
    }
    public void Deactivate()
    {
        manager.DeactivateTowerPalette();
        SetAllTowerPlacesWhite();
    }

    public void SetAllTowerPlacesWhite()
    {
        GameObject[] towerPlaces = GameObject.FindGameObjectsWithTag("TowerPlace");
        foreach (GameObject place in towerPlaces)
        {
            place.GetComponent<TowerPlace>().SetWhiteColor();
        }
    }
    public void SetWhiteColor()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
    }

}
