using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MoveObject
{

    private Animator anim;

    private Vector3 sizeBox;

    private bool canMove = true;

    public GameObject bullet ; 


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sizeBox = GetComponent<BoxCollider2D>().size;
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
        body.velocity = new Vector3(body.velocity.x, high * 20f);
    }

    void Move(int direction)
    {
        if (!canMove)
        {
            direction = 0;
        }

        body.velocity = new Vector3(moveSpeed * direction, body.velocity.y);

        if(anim!=null){
            anim.SetFloat("Move", Mathf.Abs(direction));
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

    void StopMove()
    {
        canMove = false;
    }

    void resumeMove()
    {
        if(anim!=null){
            anim.ResetTrigger("Shoot");
        }
        canMove = true;
    }

    void Flip()
    {
        Vector3 scale = body.transform.localScale;
        scale.x *= -1;
        body.transform.localScale = scale;
        faceRight = !faceRight;
    }

    void Skill_FireBullet()
    {
        StopMove();
        if(anim!=null){
            anim.SetTrigger("Shoot");
        }
        float width = ( sizeBox.x / 2 + 1f) * Mathf.Abs(transform.localScale.x);
        Vector3 originPos;
        if (faceRight)
        {
            originPos = new Vector3(transform.position.x + width, transform.position.y);
            // Debug.DrawRay(originPos, Vector3.right, Color.red);
        }
        else
        {
            originPos = new Vector3(transform.position.x - width, transform.position.y);
            // Debug.DrawRay(originPos, Vector3.left, Color.red);
        }
        GameObject bulletInstance = Instantiate(bullet,originPos,new Quaternion());
        Bullet bul = bulletInstance.GetComponent<Bullet>();
        bul.faceRight = faceRight;
        if(anim==null){
            this.canMove = true;
        }
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
