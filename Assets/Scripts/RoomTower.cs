using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTower : MonoBehaviour {
    public GameObject roomStarting;
    public GameObject roomEnding;
    public GameObject[] roomArray;

    public int layers = 8;

    public GameObject[] rooms;

    // create starting room, create layers, create ending room

    private void Start() {
        rooms = new GameObject[layers + 2];

        rooms[0] = Instantiate(roomStarting, transform, false);

        for (int i = 1; i <= layers; i++) {
            rooms[i] = Instantiate(roomArray[(int) Random.Range(0, roomArray.Length)], transform, false);

			foreach (DoorTeleporter door in rooms[i].GetComponent<RoomController>().doors) {
				door.gameObject.SetActive(false);
			}
		}

        rooms[layers + 1] = Instantiate(roomEnding, transform, false);

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
		}
    }
}
