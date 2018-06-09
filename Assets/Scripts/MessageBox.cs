using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour {
	public string[] messages;
	public bool destroy = false;

	private void OnTriggerEnter(Collider other) {
		
		foreach (string message in messages) {
			TextMessage.AddMessage(message);
		}

		if (destroy) {
			Destroy(gameObject);
		}
	}
}
