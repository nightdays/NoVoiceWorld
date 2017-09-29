using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MoveObject
{


    private Rigidbody2D rigidbody2d;

    private float moveSpeed = 8f;

    private Animator anim;

    Weapon weapon;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
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


        if (Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }


        if (Input.GetKey(KeyCode.D))
        {
            Move(1);
        }

        if(Input.GetKeyDown(KeyCode.F)){
            weapon.Fire(this);
        }
    }
    void Jump(int high)
    {
        rigidbody2d.velocity = new Vector3(rigidbody2d.velocity.x, high * 20f);
    }

    void Move(int direction)
    {
        rigidbody2d.velocity = new Vector3(moveSpeed * direction, rigidbody2d.velocity.y);

        if (anim != null)
        {
            anim.SetTrigger("move");
        }

        if (direction < 0 && faceRight)
        {
            Flip();
        }

        if (direction > 0 && !faceRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        Vector3 scale = rigidbody2d.transform.localScale;
        scale.x *= -1;
        rigidbody2d.transform.localScale = scale;
        faceRight = !faceRight;
    }


}
