using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStart : World{

    public GameObject btns;
    public GameObject anyKey;

    void Update(){
        if(Input.anyKey){
            btns.SetActive(true);
            anyKey.SetActive(false);
        }
    }
}
