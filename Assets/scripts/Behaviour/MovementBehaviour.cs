﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : StateMachineBehaviour {

 public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
	 animator.GetComponentInParent<Controller>().lockMove =false;
	 animator.GetComponentInParent<Controller>().Move(0);
 }
	
}