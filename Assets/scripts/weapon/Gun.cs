using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    private bool bulletFaceRight = true;

    public override void Fire(MoveObject fireObject)
    {
        print(fireObject.faceRight);
        if (fireObject.faceRight)
        {
            float width = sizeBox.x / 2 * transform.localScale.x + 0.5f;
            Vector3 origin = new Vector3(transform.position.x + width, transform.position.y);
            GameObject bulletInst = Instantiate(bullet, origin, new Quaternion());
            bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector3(20f, 0);

        }
        else
        {
            float width = sizeBox.x / 2 * transform.localScale.x + 0.5f;
            Vector3 origin = new Vector3(transform.position.x - width, transform.position.y);
            GameObject bulletInst = Instantiate(bullet, origin, new Quaternion());
            Vector3 scale = bulletInst.transform.localScale;
            scale.x *= -1;
            bulletInst.transform.localScale = scale;
            bulletFaceRight = false;
            bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector3(-20f, 0);
        }

    }

}
