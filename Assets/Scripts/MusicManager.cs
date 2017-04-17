using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour{
	public AudioClip main, boss, win;
	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
			if (!audioSource.loop) {
				audioSource.loop = true;
			}
		} else if (SceneManager.GetActiveScene ().buildIndex < 5) {
			if (audioSource.clip != main) {
				audioSource.clip = main;
			}
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
			if (!audioSource.loop) {
				audioSource.loop = true;
			}
		} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
			if (audioSource.loop && audioSource.clip != boss && audioSource.clip != win) {
				audioSource.clip = boss;
			}
			if (audioSource.clip == boss && !audioSource.isPlaying) {
				audioSource.Play ();
			}
			if (audioSource.clip == boss && !audioSource.loop) {
				audioSource.loop = true;
			}
		} else {
			if (audioSource.isPlaying) {
				audioSource.Stop ();
			}
		}
	}

	public void PlayWin(){
		//audioSource.Stop ();
		audioSource.clip = win;
		audioSource.loop = false;
		audioSource.Play ();
	}
}