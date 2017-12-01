using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 2f;

    public int direction = 1;

    protected Rigidbody2D body;

	void Awake () {
		body = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        body.velocity = new Vector3(direction * speed , body.velocity.y);
	}
}
