﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBattle : Controller {

	// Use this for initialization
	void Start () {
		
	}

	public override void  Control() {
		base.Control();

		if(Input.GetKeyDown(KeyCode.Z)) {
			anim.SetInteger("Attack",anim.GetInteger("Attack") + 1);
		}
	}
	
}