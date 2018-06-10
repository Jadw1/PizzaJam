using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextMessage : MonoBehaviour {

	private static TextMessage INSTANCE = null;

	private int typeSpeed = 5;
	private int typeTimer = 0;
	private int delayTicks = 0;

	private bool typing = false;

	private string message = "";

	private Text text;

	private Queue<string> queue = new Queue<string>();
	private Queue<int> delayQueue = new Queue<int>();

	public AudioClip[] keyStrokes;
	public AudioSource audio;

	private void Start() {
		INSTANCE = this;

		text = GetComponent<Text>();

		text.text = "";

		addMessage("Welcome!");
		addMessage("Follow the only path to get a piece of pizza.");
		addMessage("Remember to remember the route.");
	}


	private void FixedUpdate() {
		typeTimer++;

		if (typeTimer > typeSpeed) {
			typeTimer -= typeSpeed;

			if (message.Length > 0) {
				text.text += message[0];
				message = message.Remove(0, 1);

				// Play sound here.
				audio.PlayOneShot(keyStrokes[Random.Range(0, keyStrokes.Length)]);

			} else if (delayTicks > 0) {
				delayTicks--;
			} else {
				typing = false;
			}
		}

		if (!typing && queue.Count > 0) {
			setMessage(queue.Dequeue());
			delayTicks = delayQueue.Dequeue();
		} else if (!typing) {
			text.text = "";
		}
	}

	public void setMessage(string message) {
		this.message = message;
		text.text = "";
		typing = true;
	}

	public void addMessage(string message) {
		addMessage(message, 10);
	}

	public void addMessage(string message, int delay) {
		this.queue.Enqueue(message);
		this.delayQueue.Enqueue(delay);
	}

	public bool isTyping() {
		return typing;
	}

	public static void AddMessage(string message, int delay) {
		if (INSTANCE != null) INSTANCE.addMessage(message, delay);
	}

	public static void AddMessage(string message) {
		if (INSTANCE != null) INSTANCE.addMessage(message);
	}
}
