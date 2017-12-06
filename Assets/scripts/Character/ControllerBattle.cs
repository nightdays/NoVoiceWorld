using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBattle : Controller {

	public GameObject bullet;

	protected override void Control() {
		base.Control();
		Fire();
	}

	void Fire() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			GameObject bulletFire = GameObject.Find("BulletFire");
			bullet.GetComponent<Bullet>().direction = direction ;
			Instantiate(bullet,bulletFire.transform.position,bulletFire.transform.rotation);
		}

		if(Input.GetKeyDown(KeyCode.C)){
			this.lockMove = true;
			this.GetComponentInChildren<Animator>().SetTrigger("rush");
			body.velocity = new Vector3(10f * direction, body.velocity.y);
		}
	}
}
