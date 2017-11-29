using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private float speed = 200f;

	protected Rigidbody2D body;

	protected Animator anim;

	//跳跃高度
	private float jumpHeight = 10f;

	//是否在地板上
	private bool isGround = true;

	void Awake(){
		body = GetComponent<Rigidbody2D>();
		//由于anim是放于Sprite的，因此需要从子组件去拿
		anim = GetComponentInChildren<Animator>();
	}



	 void Update() {

		Control();
		StateMachine();

	}

	public virtual void Control() {
			 //抬起某个键
		bool upKey = Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow);

		//按下键处理  GetKey可以一直接受处理 GetKeyDown只会有一次，就是按下的时候
		if(Input.GetKey(KeyCode.RightArrow)) {
			Move(1);
			Direction(0);
		}

		if(Input.GetKey(KeyCode.LeftArrow)) {
			Move(-1);
			Direction(1);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			Jump();
		}

		//抬起按键
		if(upKey) {
			Move(0);
		}
	}

	//状态机 用于设置状态
	void StateMachine() {
		anim.SetBool("Ground", isGround);
		anim.SetFloat("Y", body.velocity.y);
	}

	//跳跃
	public void Jump() {
		if(isGround){
	 		body.velocity = new Vector3(body.velocity.x, jumpHeight);
			anim.SetTrigger("Jump");
		}
	}

	void OnCollisionStay2D(Collision2D col){
		//这里先暂时这样写，后面会有对碰撞物的判定
		isGround = true;
	}

	void OnCollisionExit2D(Collision2D col){
		//这里先暂时这样写，后面会有对碰撞物的判定
		isGround = false;
	}

	//角色移动
	public void Move(int i) {
		body.velocity = new Vector3(i*speed*Time.deltaTime, body.velocity.y);
		//设置动画
		anim.SetFloat("Move", Mathf.Abs(i));
	}

	//转向 其实就是直接修改当前对象的transform 
	public void Direction(int i) {
		//设置欧拉角度 i的取值是0或者1  如果方向是右边，那么不转向因此为0，如果是左边，那么需要转向，因此方向为1
		transform.eulerAngles = new Vector3(0,180*i,0);
	}

}
