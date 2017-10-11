using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MoveObject
{


    private Rigidbody2D rigidbody2d;

    private float moveSpeed = 8f;

    private Animator anim;

    private Vector3 sizeBox;

    private bool canMove = true;


    void Start()
    {
        sizeBox = GetComponent<BoxCollider2D>().size;
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        KeyDeal();
    }

    public void KeyDeal()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Move(0);
        }


        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            Jump(5);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Jump(1);
        }


        if (!Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }


        if (!Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.D))
        {
            Move(1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Skill_FireBullet();
        }

    }
    void Jump(int high)
    {
        rigidbody2d.velocity = new Vector3(rigidbody2d.velocity.x, high * 20f);
    }

    void Move(int direction)
    {
        if (!canMove) {
            direction = 0;
        }

        rigidbody2d.velocity = new Vector3(moveSpeed * direction, rigidbody2d.velocity.y);

        anim.SetFloat("Move", Mathf.Abs(direction));

        if (direction < 0 && faceRight)
        {
            Flip();
        }

        if (direction > 0 && !faceRight)
        {
            Flip();
        }
    }

    void StopMove()
    {
        canMove = false;
    }

    void resumeMove()
    {
        anim.ResetTrigger("Shoot");
        canMove = true;
    }

    void Flip()
    {
        Vector3 scale = rigidbody2d.transform.localScale;
        scale.x *= -1;
        rigidbody2d.transform.localScale = scale;
        faceRight = !faceRight;
    }

    void Skill_FireBullet()
    {
        StopMove();
        anim.SetTrigger("Shoot");
    }

    void TestRay()
    {
        sizeBox = GetComponent<BoxCollider2D>().size;
        float width = sizeBox.x / 2 * Mathf.Abs(transform.localScale.x) + 0.1f;
        Vector3 originPos;
        if (faceRight)
        {
            originPos = new Vector3(transform.position.x + width, transform.position.y);
            Debug.DrawRay(originPos, Vector3.right, Color.red);
        }
        else
        {
            originPos = new Vector3(transform.position.x - width, transform.position.y);
            Debug.DrawRay(originPos, Vector3.left, Color.red);
        }
    }


}
