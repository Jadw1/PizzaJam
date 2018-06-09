using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public AudioClip[] clips;

	private AudioSource audio;

	private void Start() {
		audio = GetComponent<AudioSource>();
	}

	private void Update() {
		if (!audio.isPlaying) {
			audio.clip = clips[Random.Range(0, clips.Length)];
			audio.Play();
		}
	}
}
