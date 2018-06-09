using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleporter : MonoBehaviour {
	public DoorTeleporter link;
	public bool hasLeft = true;

	private void Start() {
		hasLeft = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (link == null) return;

		if (other.tag == "Player" && hasLeft == true) {
			hasLeft = true;

			Vector3 relPos = other.transform.position - transform.position;
			float angularDifference = link.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;

			relPos = Quaternion.Euler(0, angularDifference, 0) * relPos;
			other.transform.Rotate(Vector3.up, angularDifference + 180.0f);

			other.transform.position = link.transform.position + relPos;

			link.hasLeft = false;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Player" && hasLeft == false) hasLeft = true;
	}
}
