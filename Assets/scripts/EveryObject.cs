using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EveryObject : MonoBehaviour {


	public void DestroyObject(){
		Destroy(gameObject);
	}

	
}
