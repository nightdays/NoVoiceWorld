using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource bgm;
	public AudioSource se;

	//当我们需要播放音乐的时候，就直接播放
	public void PlaySE(AudioClip clip) {
		se.PlayOneShot(clip);
	}
}
