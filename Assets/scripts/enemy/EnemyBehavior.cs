using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MoveObject
{

    int i = 90;

    int count = 100;

    bool once = true;

    Vector3 sizeBox;

    void Start()
    {
        sizeBox = GetComponent<BoxCollider2D>().size;
    }

    void Update()
    {
        if (once)
        {
            LookAround();
        }
    }

    void LookAround()
    {
        // Vector3 origin = transform.position;
        // for (int i = 0; i <= 90; i++)
        // {
        //     float r = 5f;
        //     float fd = i * Mathf.PI / 180;
        //     float x = r * Mathf.Cos(fd);
        //     float y = r * Mathf.Sin(fd);
        //     Vector3 target = new Vector3(origin.x + x, origin.y + y);
        //     Debug.DrawLine(transform.position, target, Color.red);
        // }
        float width = sizeBox.x / 2 * transform.localScale.x + 0.5f;
        Vector3 origin = new Vector3(transform.position.x + width, transform.position.y);
        float distance = 20f;
        for (int i = 0; i <= 90; i++)
        {
                float fd = i * Mathf.PI / 180;
                float x = distance * Mathf.Cos(fd);
                float y = distance * Mathf.Sin(fd);
                Vector3 target = new Vector3(origin.x + x, origin.y + y);
                // RaycastHit2D hit = Physics2D.Raycast(origin , )
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
                // memoryPlayerPosition.x = hit.collider.GetComponent<Rigidbody2D>().transform.position.x;
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