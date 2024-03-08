using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hook : MonoBehaviour
{
    public Transform itemHolder;
    [SerializeField] HookMovement hookMovement;
    [SerializeField] Spawner spawner;
    string temp;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI xText;
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject gameOverPanel;
    public bool correctAnswer = false;
    public float highScore = 0f;
    float score = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            hookMovement.isReturning = true;
            hookMovement.move_Down = false;
            collision.gameObject.transform.SetParent(itemHolder);
            collision.gameObject.transform.localPosition = Vector3.zero;
            collision.gameObject.transform.localRotation = Quaternion.identity;
        }
        if (collision.gameObject.CompareTag("Player") && itemHolder.childCount > 0)
        {
            temp = itemHolder.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text;
            if (spawner.bilesen == temp)
            {
                GameWin();
                hookMovement.transform.position = hookMovement.hookPosition;
            }
            else
            {
                WrongAnswer();
                if (score < 0)
                {
                    GameOver();
                }
                Destroy(itemHolder.GetChild(0).gameObject);
                hookMovement.transform.position = hookMovement.hookPosition;
            }
        }
    }

    void GameWin()
    {
        score += 10f;
        if (score > highScore)
        {
            highScore = score;
        }
        scoreBoard.text = "Score: " + score.ToString();
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            Destroy(item);
        }

        Debug.Log("Congrats");
        Destroy(itemHolder.GetChild(0).gameObject);
        animator.SetBool("isCheer", true);
        spawner.SpawnObjects();

        // Pass the action to be executed after the wait
        StartCoroutine(Wait(() =>
        {
            animator.SetBool("isCheer", false);


        }));
    }

    void WrongAnswer()
    {
        score -= 10f;
        scoreBoard.text = "Score: " + score.ToString();
        StartCoroutine(FlashXTimes(2));
    }

    void GameOver()
    {
        scoreBoard.gameObject.SetActive(false);
        Time.timeScale = 0f;
        highScoreText.text = "High Score: " + highScore.ToString();
        gameOverPanel.SetActive(true);
    }

    IEnumerator FlashXTimes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Bekleme öncesi durumu iþle
            xText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);

            // Bekleme sonrasý durumu iþle
            xText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void RestartGame()
    {
        scoreBoard.gameObject.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Wait(Action action)
    {
        yield return new WaitForSeconds(2f);

        // Execute the action after the wait
        action.Invoke();
    }

    private void Update()
    {
        // Add any update logic if needed
    }
}
