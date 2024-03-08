using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    public float min_Z = -65f, max_Z = 65f;
    public float rotate_Speed = 120f;
    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;
    public Vector3 hookPosition;
    [SerializeField]
    Animator animator;

    public float move_Speed = 2f;
    private float initial_Move_Speed;

    public float min_Y = -2.5f;
    private float initial_Y;

    public bool move_Down;
    public bool isReturning;

    private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        hookPosition = transform.position;
        initial_Y = transform.position.y;
        initial_Move_Speed = move_Speed;

        canRotate = true;
    }

    void Update()
    {
        animator.SetBool("isPulling", !canRotate);
        GetInput();
        MoveRope();
        Rotate();
    }

    void Rotate()
    {
        if (!canRotate)
        {
            return;
        }

        if (rotate_Right)
        {
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }
        else
        {
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle, Vector3.forward);

        if (rotate_Angle >= max_Z)
        {
            rotate_Right = false;
        }
        else if (rotate_Angle <= min_Z)
        {
            rotate_Right = true;
        }
    }

    void GetInput()
    {
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && canRotate && !isReturning)
        {
            canRotate = false;
            move_Down = true;
        }
    }

    void MoveRope()
    {
        if (canRotate)
        {
            return;
        }

        if (!canRotate)
        {
            Vector3 temp = transform.position;

            if (move_Down)
            {
                temp -= transform.up * move_Speed * Time.deltaTime;
            }
            else
            {
                temp += transform.up * move_Speed * Time.deltaTime;
            }

            transform.position = temp;

            if (temp.y <= min_Y)
            {
                move_Down = false;
                isReturning = true;
            }

            if (temp.y >= initial_Y)
            {
                canRotate = true;
                ropeRenderer.RenderLine(temp, false);
                move_Speed = initial_Move_Speed;
                isReturning = false;
            }

            ropeRenderer.RenderLine(transform.position, true);
        }
    }
}