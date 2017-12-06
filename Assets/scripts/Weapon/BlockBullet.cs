using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBullet : Bullet {

    public override void Init() {
        base.Init();
        this.speed = 10f;
    }
}
