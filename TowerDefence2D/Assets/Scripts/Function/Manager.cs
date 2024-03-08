using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Vector3 mousePosition;
    Vector2 mousePosition2D;
    RaycastHit2D hit;
    public bool isClicked;
    public bool isTowerPlaced = false;
    public GameObject place;
    public Transform coordinate;
    public float money = 100f;
    public float health = 20f;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public int levelIndex = 0;
    public bool isNextLevelClicked = false;

    public GameObject towerPalette;
    TowerPlace towerPlace;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public void SetTowerPlaceReference(TowerPlace towerRef)
    {
        towerPlace = towerRef;
    }

    public void Stars()
    {
        if (health == 20)
        {
            star3.SetActive(true);
        }

        else if (health < 20 && health > 10)
        {
            star2.SetActive(true);
        }
        else if (health < 10)
        {
            star1.SetActive(true);
        }
        else if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    } 
    public void RestartVariables()
    {
        money = 100f;
        health = 20f;
    }

    public void DeactiveStars()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    private void Update()
    {
        moneyText.text = money.ToString();
        healthText.text = health.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);
            hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);

                isClicked = true;
            }
            else
            {
                isClicked = false;
                towerPlace.Deactivate();
            }
        }
    }

    public void ActivateTowerPalette()
    {
        towerPalette.SetActive(true);

    }

    public void DeactivateTowerPalette()
    {
        towerPalette.SetActive(false);
    }

}
