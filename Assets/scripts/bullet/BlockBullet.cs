using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBullet : Bullet
{

    public GameObject bulletBoom;

    private int moveSpeed = 100;

    private int damage = 10;

    private Rigidbody2D body ;

    void Start()
    {
        this.deadCount = 100;
        body = GetComponent<Rigidbody2D>();
        
    }

     void  Update()
    {
        base.Update();
        // CollisionCheck();
        int direction = 1;
        if(!faceRight){
            direction = -1;
        }
        Move(direction);
    }

    void Move(int direction)
    {

        body.velocity = new Vector3(moveSpeed * direction, body.velocity.y);

    }

    void CollisionCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, faceRight ? Vector3.right : Vector3.left, 10000f);
        if (hit.collider)
        {
            if (hit.collider.name.IndexOf("bulletBoom") > -1) { DestroyObject(); return; }
            if (hit.collider.tag.IndexOf("Enemy") > -1)
            {
                this.HitEnemy(hit);
            }
        }
        DestroyObject();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "enemy")
        {
            EnemyLife enemyLife = collider.gameObject.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.Hurt(damage);
                DestroyObject();
            }
        }else if(collider.gameObject.tag == "wall"){
            DestroyObject();
        }

    }


    //碰到敌人时所触发的方法
    void HitEnemy(RaycastHit2D hit)
    {
        EnemyLife enemyLife = hit.collider.gameObject.GetComponent<EnemyLife>();
        //子弹设计到的敌人 有没有EnemyLife这个脚本
        if (enemyLife != null)
        {
            enemyLife.Hurt(damage);
        }
        //撞击特效
        if (bulletBoom != null)
        {
            Vector3 position = new Vector3(hit.point.x - bulletBoom.GetComponent<BoxCollider2D>().size.x / 2, hit.point.y);
            // Debug.DrawLine(position,new Vector3(position.x + 1000 , position.y), Color.red);
            Boom(position);
        }
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
