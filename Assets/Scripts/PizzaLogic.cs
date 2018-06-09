using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLogic : MonoBehaviour {
	public RoomTower tower;

	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);

		tower.pizzaTaken();
	}
}
