using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLogic : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);

		GameObject obj = GameObject.FindGameObjectWithTag("RoomStack");
		RoomTower tower = obj.GetComponent<RoomTower>();
		tower.pizzaTaken();
	}
}
