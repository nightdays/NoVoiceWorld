using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int hp = 100;

    public void  Hurt(int dmg) {
        this.hp -= dmg ;
        if(this.hp<=0){
            Destroy(this);
        }
    }
}