using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    private Rigidbody birdRB;
    private float jumpForce = 5.2f;
    public bool isGameOver = false;
    GameManager gameManagerScript;
    AudioSource jumpSound;
    AudioSource pointSound;


    void Start()
    {
        birdRB = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        pointSound = GameObject.Find("PointSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckHeight();
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            jumpSound.Play();
            birdRB.velocity = Vector3.up * jumpForce;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
            isGameOver = true;
        }
        if (other.gameObject.tag == "Point" && !isGameOver)
        {
            Debug.Log("Collected");
            gameManagerScript.score++;
            pointSound.Play();
        }
    }
    void CheckHeight()
    {
        if (transform.position.y < -1 || transform.position.y > 15)
        {
            isGameOver = true;
        }
    }
}
