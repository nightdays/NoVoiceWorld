using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public SoundManager sound;

    void Awake(){
        //像这种遍历函数，只建议放在初识加载中，不建议放于Update
        sound = Object.FindObjectOfType<SoundManager>();
    }

}
