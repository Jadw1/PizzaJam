using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureRandomizer : MonoBehaviour {
	public GameObject[] furniture;

	private void Start() {
		foreach (GameObject mebel in furniture) {
			mebel.SetActive(Random.Range(0.0f, 100.0f) <= 25.0f ? true : false);
		}
	}
}
