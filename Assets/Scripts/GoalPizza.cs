using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPizza : MonoBehaviour {
	public GameObject[] pieces;

	int completed = 0;
	bool finished = false;
	bool returned = false;

	private void Start() {
		foreach (GameObject piece in pieces) {
			piece.SetActive(false);
		}
	}

	public int CurrentState() {
		return completed;
	}

	public void AddPiece() {
		returned = false;

		TextMessage.AddMessage("Now go back to assemble the pizza!");

		if (!finished) {
			pieces[completed++].SetActive(true);
		}

		if (completed == pieces.Length) {
			finished = true;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (!returned) {
			returned = true;

			if (!finished) {
				TextMessage.AddMessage((8-completed) + " pieces left to collect, go back.");
				if(completed != 0) {
                    GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>().GenerateLevel(completed);
                }
			} else {
				// Player won the game.
			}
		}
	}
}
