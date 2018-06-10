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

	public void pizzaTaken() {
		for (int i = 1; i < rooms.Length - 1; i++) {
			rooms[i].GetComponent<RoomController>().RandomizeConnections(rooms[rooms.Length-1].GetComponent<RoomController>());
		}
	}

	private void Start() {
        rooms = new GameObject[layers + 2];

        rooms[0] = Instantiate(startRoom, transform, false);

        for (int i = 1; i <= layers; i++) {
            rooms[i] = Instantiate(roomArray[Random.Range(0, roomArray.Length)], transform, false);
            rooms[i].GetComponent<RoomController>().DeactivateDoors(i);			
		}

        rooms[layers + 1] = Instantiate(endRoom, transform, false);

        for(int i = 0; i < rooms.Length; i++) {
            rooms[i].transform.localPosition = new Vector3(0.0f, 5.0f * i, 0.0f);
        }

        for (int i = 0; i < rooms.Length - 1; i++) {
            PortalManager.MergeDoors(rooms[i].GetComponent<RoomController>().exitDoor, rooms[i + 1].GetComponent<RoomController>().entryDoor);
        }
    }
}
