using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLogic : MonoBehaviour {
	public GameObject[] pieces;

    private int state;
    private bool collected = false;

	private void Start() {
		foreach (GameObject piece in pieces) {
			piece.SetActive(false);
		}

		GoalPizza pizza = GameObject.FindGameObjectWithTag("MainPizza").GetComponent<GoalPizza>();
        state = pizza.CurrentState();
        pieces[state].SetActive(true);
	}

	private void OnTriggerEnter(Collider other) {
		//Destroy(gameObject);
        if(!collected) {
		    RoomTower tower = GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>();
		    tower.pizzaTaken();

		    GoalPizza pizza = GameObject.FindGameObjectWithTag("MainPizza").GetComponent<GoalPizza>();
		    pizza.AddPiece();

            pieces[state].SetActive(false);
            collected = true;
        }
	}

    public void ActivatePiece() {
        pieces[state].SetActive(true);
        collected = false;
    }
}
