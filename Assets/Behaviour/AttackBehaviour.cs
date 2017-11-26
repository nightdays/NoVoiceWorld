using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour {

	public int order;

	public float transhold;

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//animator就是当前播放这段动画的animator
		animator.SetInteger("Attack", 0 );
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//在一定的时间区间内Attack的值始终是order
		if(stateInfo.normalizedTime <= transhold) {
			animator.SetInteger("Attack" , order);
		}
	}

}
