using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBullet : Bullet
{

    public GameObject bulletBoom;

    void Start(){
        this.deadCount = 20000;
    }

    void Update()
    {
        CollisionCheck();
    }

    void CollisionCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, faceRight ? Vector3.right : Vector3.left, 10000f);
        if (hit.collider)
        {
            print(hit.collider.name);
            if (hit.collider.name.IndexOf("bulletBoom")>-1) { DestroyObject();return; }
            hit.collider.gameObject.GetComponent<EnemyLife>().Hurt(10);
            Vector3 position = new Vector3(hit.point.x - bulletBoom.GetComponent<BoxCollider2D>().size.x / 2, hit.point.y);
            // Debug.DrawLine(position,new Vector3(position.x + 1000 , position.y), Color.red);
            Boom(position);
        }
        DestroyObject();
    }

    void Boom(Vector3 position)
    {
        GameObject bulletBoomInstance = Instantiate(bulletBoom, new Vector3(1, 1), new Quaternion());
        bulletBoomInstance.transform.position = position;
        if (faceRight)
        {
        }
        else
        {
            Vector3 scale = bulletBoomInstance.transform.localScale;
            scale.x *= -1;
            bulletBoomInstance.transform.localScale = scale;
        }
        DestroyObject();
    }
}
