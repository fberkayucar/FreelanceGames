using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSlider : MonoBehaviour
{
    private float speed = 5f;
    private BirdControl birdControlScript;
    void Start()
    {
        birdControlScript = GameObject.Find("Bird").GetComponent<BirdControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Slider();
        DeleteObject();
    }
    void Slider()
    {
        if (!birdControlScript.isGameOver)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    void DeleteObject()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
