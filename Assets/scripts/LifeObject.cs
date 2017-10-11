using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LifeObject : EveryObject{


	//受伤
	public abstract void Hurt(int hp);

	//派系 表示是否是同一个正营
	public string factions = "";

	
}
