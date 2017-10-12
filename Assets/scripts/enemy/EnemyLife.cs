using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : LifeObject {

    private int HP = 100;

    public override void Hurt(int hp){
        HP -= hp;
    }

    void Update(){
        if(HP<=0){
            DestroyObject();
        }
    }
}