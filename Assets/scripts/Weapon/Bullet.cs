using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	protected float speed = 2f;

    public int direction = 1;

    protected Rigidbody2D body;

	public virtual void Init(){
	}

	void Awake () {
		Init();
		body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        body.velocity = new Vector3(direction * speed , body.velocity.y);
	}
}
