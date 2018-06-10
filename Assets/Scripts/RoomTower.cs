using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTower : MonoBehaviour {
    public GameObject startRoom;
    public GameObject endRoom;
    public GameObject[] roomArray;
    public int layers = 8;

    public GameObject[] rooms;
    private GameObject startRoomInstance;

	// create starting room, create layers, create ending room

	public void pizzaTaken() {
		for (int i = 1; i < rooms.Length - 1; i++) {
			rooms[i].GetComponent<RoomController>().RandomizeConnections(this);
		}
	}

	private void Start() {
        CreateStartRoom();
        GenerateLevel(0);
    }

    private void CreateStartRoom() {
        startRoomInstance = Instantiate(startRoom, transform, false);
        startRoomInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void GenerateLevel(int levelindicator) {
        layers = levelindicator + 1;
        rooms = new GameObject[layers + 1];

        for (int i = 0; i < layers; i++) {
            rooms[i] = Instantiate(roomArray[Random.Range(0, roomArray.Length)], transform, false);
            rooms[i].GetComponent<RoomController>().DeactivateDoors(i);
            rooms[i].transform.localPosition = new Vector3(0.0f, 5.0f * (i + 1), 0.0f);
        }

        rooms[layers] = Instantiate(endRoom, transform, false);
        rooms[layers].transform.localPosition = new Vector3(0.0f, 5.0f * (layers + 1), 0.0f);

        PortalManager.MergeDoors(startRoomInstance.GetComponent<RoomController>().exitDoor, rooms[0].GetComponent<RoomController>().entryDoor);
        for (int i = 0; i < rooms.Length - 1; i++) {
            PortalManager.MergeDoors(rooms[i].GetComponent<RoomController>().exitDoor, rooms[i + 1].GetComponent<RoomController>().entryDoor);
        }
    }
}
