using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenUI : MonoBehaviour {

	public Image black ;

	public float speed = 0.05f;


	private int sceneId;
	private string sceneName;

	void Awake(){
		FadeIn();
	}

	void Update() {
		
		float a = black.color.a + speed;
		a = Mathf.Clamp(a,0,1);		
		black.color = new Color(black.color.r,black.color.g, black.color.b, a);
	}


	//画面慢慢顯示出來 说白了就是 从黑色变为无色
	public void FadeIn() {
		//设置黑色 沾满全屏
		black.color = new Color(black.color.r,black.color.g, black.color.b , 1);
		//然后开始递减
		speed = -Mathf.Abs(speed);
	}

	//画面渐渐消失 说白了 就是 从无色变为黑色
	public void FadeOut() {
		black.color = new Color(black.color.r,black.color.g, black.color.b , 0);
		speed = Mathf.Abs(speed);
	}


	//淡出跳转
	public void FadeAndGo(string sceneName){
		this.sceneName = sceneName;
		FadeOut();
		Invoke("LoadSceneByName",.5f);
	}
	//淡出跳转
	public void FadeAndGo(int sceneId){
		this.sceneId = sceneId;
		FadeOut();
		Invoke("LoadSceneById",.5f);
	}

	public void LoadSceneById(){
        SceneManager.LoadScene(sceneId);
		
    }
	public void LoadSceneByName() {
		SceneManager.LoadScene(sceneName);
	}


}
