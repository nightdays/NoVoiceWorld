using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObject : EveryObject
{


    protected Rigidbody2D body;

    /*
        body.velocity = new Vector3(moveSpeed * direction, body.velocity.y);
    */
    protected float moveSpeed = 8f;

    public bool faceRight = true;


}
