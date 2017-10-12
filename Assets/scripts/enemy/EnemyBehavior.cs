using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MoveObject
{

    int i = 90;

    int count = 100;

    bool once = true;

    private bool findTarget = false;

    private Vector3 targetPosition;

    private Vector3 sizeBox;

    private int idleCount = 100;

    private Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sizeBox = GetComponent<BoxCollider2D>().size;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        LookAround();
        if(!findTarget) {
            Idle();
        }
    }

    void Idle()
    {
        if (idleCount > 0)
        {
            if (faceRight)
            {
                Move(1);
            }
            else
            {
                Move(-1);
            }
            idleCount--;
        }
        else
        {
            idleCount = 100;
            Flip();
        }
    }

    void Move(int direction)
    {
        // if (!canMove)
        // {
        //     direction = 0;
        // }
        body.velocity = new Vector3(0 * direction, body.velocity.y);

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

    void Flip()
    {
        Vector3 scale = body.transform.localScale;
        scale.x *= -1;
        body.transform.localScale = scale;
        faceRight = !faceRight;
    }

    void LookAround()
    {
        float width = sizeBox.x / 2 * transform.localScale.x + 0.5f;
        int dir = 1;
        if(!faceRight){
            dir = -1;
            print(dir);
        }
        Vector3 origin = new Vector3(transform.position.x + dir * width, transform.position.y);
        float distance = 20f;
        for (int i = 0; i <= 90; i++)
        {
            float fd = i * Mathf.PI / 180;
            float x = distance * Mathf.Cos(fd) * dir;
            float y = distance * Mathf.Sin(fd);
            Vector3 target = new Vector3(origin.x + x, origin.y + y);
            RaycastHit2D hit = Physics2D.Raycast(origin , target, 10000f);
            Debug.DrawLine(origin, target , Color.red);
            if(hit){
            }
            if(hit && hit.collider.name.IndexOf("player")>-1){
                findTarget = true;
                targetPosition = hit.collider.transform.position;
                break;
            }
        }

        if(findTarget){
            if( (targetPosition.x - transform.position.x ) > 0 ) {
                Move(1);
            }else {
                Move(-1);
            }
        }


    }

    void SeenLeft()
    {
        float width = sizeBox.x / 2 * transform.localScale.x + 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x - width, transform.position.y), Vector2.left, 10000f);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name.Equals("robot"))
            {
                // memoryPlayerPosition.x = hit.collider.GetComponent<body>().transform.position.x;
                // memoryPlayerPosition.y = transform.position.y;
                // memoryCount = memoryCountConst;
            }
            else
            {
                // memoryPlayerPosition = null;
            }
        }
    }
}