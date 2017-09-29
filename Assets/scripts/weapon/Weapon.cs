using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : EveryObject
{

    public GameObject bullet;

    public Vector3 sizeBox;

    void Start()
    {
        if(GetComponent<BoxCollider2D>()!=null){
            sizeBox = GetComponent<BoxCollider2D>().size;
        }
    }

    public abstract void Fire(MoveObject fireObject);

}
