using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    protected float speed = 200f;

    protected float jumpHeight = 10f;

    protected Rigidbody2D body;

    protected int direction = 1;

    public bool lockMove = false;

    void Awake () {
        Physics2D.IgnoreLayerCollision(8,9 , true);
        body = GetComponent<Rigidbody2D>();
    }
	
    void Update() {
        Control();
    }

    protected virtual void Control() {
        bool upMoveKey = Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow);

        if(Input.GetKey(KeyCode.LeftArrow)) {
            Move(-1);
            Direction(-1);
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            Move(1);
            Direction(0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();
        }

        if(upMoveKey){
            Move(0);
        }
    }

    public void Move(int i)  {
        if(lockMove) {
            return;
        };
        body.velocity = new Vector3(i*speed * Time.deltaTime, body.velocity.y);
    }

    void Direction(int i)  {
        direction = i==0?1:-1;
        transform.eulerAngles = new Vector3(0, 180 * i, 0) ; 
    }

    void Jump(){
        if(lockMove) {
            return;
        };
        body.velocity = new Vector3( body.velocity.x, jumpHeight); 
    }
}
