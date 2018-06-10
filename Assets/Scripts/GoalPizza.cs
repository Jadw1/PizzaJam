using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPizza : MonoBehaviour {
	public GameObject[] pieces;

	int completed = 0;
	int ticksPerPiece = 5;
	int timer = 0;
	bool finished = false;
	bool returned = true;
	bool eating = false;

	private void Start() {
		foreach (GameObject piece in pieces) {
			piece.SetActive(false);
		}
	}

    public void ResetLevel() {
        if (!returned) {
            returned = true;
            if (finished) {
                finished = false;
            }
            pieces[--completed].SetActive(false);
        }

       
        GameObject.FindGameObjectWithTag("PizzaPiece").GetComponent<PizzaLogic>().ActivatePiece();
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

	public void EatPizza() {
		eating = true;
	}

	private void FixedUpdate() {
		if (eating) {
			timer++;

			if (timer >= ticksPerPiece) {
				timer -= ticksPerPiece;

				completed--;

				pieces[completed].SetActive(false);

				if (completed == 0) {
					RoomTower tower = GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>();
					tower.GenerateLevel(0);

					finished = false;
					returned = true;
					eating = false;
					timer = 0;
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (!returned) {
			returned = true;
            PortalManager.CloseAllDoors();

            RoomTower tower = GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>();

            if (!finished) {
				TextMessage.AddMessage((8 - completed) + " pieces left to collect, go back.");
				if (completed != 0) {
					tower.GenerateLevel(completed);
				}
			} else {
                // Player won the game.
                PortalManager.MergeDoors(tower.GetStartRoomDoor(), tower.GetStartRoomDoor());
			}
		}
	}

}
