using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLogic : MonoBehaviour {
	public GameObject[] pieces;

	private void Start() {
		foreach (GameObject piece in pieces) {
			piece.SetActive(false);
		}

		GoalPizza pizza = GameObject.FindGameObjectWithTag("MainPizza").GetComponent<GoalPizza>();
		pieces[pizza.CurrentState()].SetActive(true);
	}

	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);

		RoomTower tower = GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>();
		tower.pizzaTaken();

		GoalPizza pizza = GameObject.FindGameObjectWithTag("MainPizza").GetComponent<GoalPizza>();
		pizza.AddPiece();
	}
}
