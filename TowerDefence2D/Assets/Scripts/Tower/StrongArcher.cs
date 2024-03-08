using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongArcher : MonoBehaviour
{
    Animator animator;
    public bool isShooting = false;
    public Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isShooting", isShooting);

        // Hedef varsa, hedefin sa��nda m� solunda m� oldu�unu kontrol et
        if (target != null)
        {
            FlipSprite(target.position.x > transform.position.x);
        }
    }

    // Sprite'� sa�a veya sola �eviren yard�mc� fonksiyon
    private void FlipSprite(bool isRight)
    {
        if (isRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Sa�a d�n�k
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Sola d�n�k
        }
    }
}
