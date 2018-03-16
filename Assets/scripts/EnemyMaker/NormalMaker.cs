using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMaker : MonoBehaviour {


	GameObject enemy  ;

	GameObject player;

	void Awake()
	{
		enemy	= (GameObject)Resources.Load("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
	}

	int count = 100;

	void Update () {
		count --;
		if(count ==0) {
			Instantiate(enemy, randomPosition(), new Quaternion());
			count = 100;
		}	
	}

	Vector3 randomPosition() {
		float playerY = player.transform.position.y;
		float playerX = player.transform.position.x;
		float min = playerX - 5f;
		float max = playerX + 5f;

		float x = Random.Range(min,max);



		return getRealPosition(x , playerY);
	}

	Vector3 getRealPosition(float paramX , float paramY) {
		RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector3(paramX,paramY) , Vector3.down, 1000f);
		for(int i=0;i<hits.Length ; i++) {
			if( "Floor".Equals(hits[i].collider.tag.ToUpper())){
				return hits[i].point;
			}
		}

		return new Vector3();
	}

}
