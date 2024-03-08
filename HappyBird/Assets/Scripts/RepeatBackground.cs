using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float slideSpeed = 5f;
    public BirdControl birdControlScript;
    void Start()
    {
        birdControlScript = GameObject.Find("Bird").GetComponent<BirdControl>();
        startPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Slider();
    }
    void Slider()
    {
        if (!birdControlScript.isGameOver)
        {
            transform.Translate(Vector3.right * slideSpeed * Time.deltaTime);
            if (transform.position.x < -30f)
            {
                transform.position = startPos;
            }
        }
    }
    void AutoDelete()
    {
          if (transform.position.y < -1f)
        {
            Destroy(gameObject);
        }
    }
}
