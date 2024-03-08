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

        // Hedef varsa, hedefin saðýnda mý solunda mý olduðunu kontrol et
        if (target != null)
        {
            FlipSprite(target.position.x > transform.position.x);
        }
    }

    // Sprite'ý saða veya sola çeviren yardýmcý fonksiyon
    private void FlipSprite(bool isRight)
    {
        if (isRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Saða dönük
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Sola dönük
        }
    }
}
