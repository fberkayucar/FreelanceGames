using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    private BirdControl BirdControl;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    void Start()
    {
        BirdControl = GameObject.Find("Bird").GetComponent<BirdControl>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        GameOver();
    }
    void GameOver()
    {
        if (BirdControl.isGameOver)
        {
            gameOverText.text = "Game Over!";
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

