using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTower : MonoBehaviour {
    public GameObject startRoom;
    public GameObject endRoom;
    public GameObject[] roomArray;
    public int layers = 8;


    private GameObject[] rooms;

    // create starting room, create layers, create ending room

    private void Start() {
        rooms = new GameObject[layers + 2];

        rooms[0] = Instantiate(startRoom, transform, false);

        for (int i = 1; i <= layers; i++) {
            rooms[i] = Instantiate(roomArray[Random.Range(0, roomArray.Length)], transform, false);
            rooms[i].GetComponent<RoomController>().DeactivateDoors();			
		}

        rooms[layers + 1] = Instantiate(endRoom, transform, false);

        for(int i = 0; i < rooms.Length; i++) {
            rooms[i].transform.localPosition = new Vector3(0.0f, 5.0f * i, 0.0f);
        }

		/*GameObject pizza = GameObject.FindWithTag("Pizza");
		if (pizza != null) {
			pizza.GetComponent<PizzaLogic>().tower = this;
		}

		int last = -1;

        for (int i = 0; i < rooms.Length; i++) {
            rooms[i].name = "Room " + i;
            rooms[i].transform.localPosition = new Vector3(0, -5 * i, 0);

			if (i < rooms.Length - 1) {
				RoomController cin = rooms[i].GetComponent<RoomController>();
				RoomController cout = rooms[i + 1].GetComponent<RoomController>();

				int entranceID = Random.Range(0, cin.doors.Length);
				int exitID = Random.Range(0, cout.doors.Length);

				while (entranceID == last) entranceID = Random.Range(0, cout.doors.Length);

				last = exitID;

				DoorTeleporter entrance = cin.doors[entranceID];
				DoorTeleporter exit = cout.doors[exitID];

				entrance.gameObject.SetActive(true);
				exit.gameObject.SetActive(true);

				entrance.link = exit;
				exit.link = entrance;
			}
		}*/
    }

	/*public void pizzaTaken() {
		DoorTeleporter pizza = rooms[rooms.Length - 1].GetComponent<RoomController>().doors[0];

		foreach (GameObject room in rooms) {
			foreach(DoorTeleporter door in room.GetComponent<RoomController>().doors) {
				door.gameObject.SetActive(true);

				if (door.link == null) {
					door.link = pizza;
				}
			}
		}
	}*/
}
