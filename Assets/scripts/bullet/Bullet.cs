using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : EveryObject{
	
    protected int deadCount = 100;

    void Update(){
        if(deadCount>0){
            deadCount --;
        }else{
            DestroyObject();
        }
    }
    
}
