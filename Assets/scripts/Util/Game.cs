using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static  ScreenUI  ScreenUI() {

		return Object.FindObjectOfType<ScreenUI>();
	}
}
