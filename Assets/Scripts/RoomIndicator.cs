using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomIndicator : MonoBehaviour {
	private Text text;
	private RectTransform parent;
	public RoomController room;

	private void Start() {
		text = GetComponent<Text>();

		text.text = "Floor " + room.roomIndex;

		parent = GetComponentInParent<RectTransform>();
	}

	private void Update() {
		parent.Rotate(new Vector3(0, Time.deltaTime * -100, 0));
	}
}
