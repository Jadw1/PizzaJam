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
    private RoomController[] controllers;

	private void Start() {
        CreateStartRoom();
        GenerateLevel(0);
    }

    private void CreateStartRoom() {
        startRoomInstance = Instantiate(startRoom, transform, false);
        startRoomInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void TeleportToStart(Transform player) {
        player.position = new Vector3(2.0f, 1.0f, 2.0f);
    }

    public void TeleportToEnd(Transform player) {
        player.position = new Vector3(2.0f, 5.0f * (layers + 1) + 1.0f, 2.0f);
    }

    public void GenerateLevel(int levelindicator) {
        DeleteLevel();

        layers = levelindicator + 1;
        rooms = new GameObject[layers + 1];

        for (int i = 0; i < layers; i++) {
            rooms[i] = Instantiate(roomArray[Random.Range(0, roomArray.Length)], transform, false);
            rooms[i].GetComponent<RoomController>().DeactivateDoors(i);
            rooms[i].transform.localPosition = new Vector3(0.0f, 5.0f * (i + 1), 0.0f);
        }

        rooms[layers] = Instantiate(endRoom, transform, false);
        rooms[layers].transform.localPosition = new Vector3(0.0f, 5.0f * (layers + 1), 0.0f);

        GetRoomControllers(rooms.Length + 1);

        for (int i = 0; i < controllers.Length - 1; i++) {
            PortalManager.MergeDoors(controllers[i].exitDoor, controllers[i + 1].entryDoor);
        }
    }

    public void DeactivateDoorsInRooms() {
        for (int i = 0; i < layers; i++) {
            rooms[i].GetComponent<RoomController>().DeactivateDoors(i);
        }
    }

    private void GetRoomControllers(int amount) {
        controllers = new RoomController[amount];
        for(int i = 0; i < amount; i++) {
            if(i == 0) {
                controllers[i] = startRoomInstance.GetComponent<RoomController>();
            }
            else {
                controllers[i] = rooms[i-1].GetComponent<RoomController>();
            }
        }
    }

    private void DeleteLevel() {
        foreach(GameObject room in rooms) {
            Destroy(room);
        }
    }

    /*public void GenerataWrongDoors() {
        int level = rooms.Length - 2;

        for(int i = rooms.Length - 2; i <= 0; i--) {
            int amount = level;
            amount += (Random.Range(0, 10) < 5) ? 1 : 0;

            for(int d = 0; d < amount; d++) {

            }
        }
    }*/



	public void pizzaTaken() {
		for (int i = 1; i < rooms.Length - 1; i++) {
			rooms[i].GetComponent<RoomController>().RandomizeConnections(this);
		}
	}

    public Door GetStartRoomDoor() {
        return startRoomInstance.GetComponent<RoomController>().exitDoor;
    }
}
