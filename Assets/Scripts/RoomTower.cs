using UnityEngine;

public class RoomTower : MonoBehaviour {
    public GameObject startRoom;
    public GameObject endRoom;
    public GameObject[] roomArray;

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

    public void GenerateLevel(int levelIndicator) {
        DeleteLevel();

        int layers = levelIndicator + 1;

        rooms = new GameObject[layers + 1];

        for (int i = 0; i < layers; i++) {
            rooms[i] = Instantiate(roomArray[Random.Range(0, roomArray.Length)], transform, false);
            rooms[i].GetComponent<RoomController>().DeactivateDoors(i);
        }

        rooms[layers] = Instantiate(endRoom, transform, false);

        for (int i = 0; i < rooms.Length; i++) {
            rooms[i].transform.localPosition = new Vector3(0.0f, 5.0f * (i + 1), 0.0f);
        }

        PortalManager.MergeDoors(startRoom.GetComponent<RoomController>().exitDoor, rooms[0].GetComponent<RoomController>().entryDoor);
        for (int i = 0; i < rooms.Length - 1; i++) {
            PortalManager.MergeDoors(rooms[i].GetComponent<RoomController>().exitDoor, rooms[i + 1].GetComponent<RoomController>().entryDoor);
        }
    }

    private void DeleteLevel() {
        for(int i=0; i<rooms.Length; i++) {
            Destroy(rooms[i]);
        }
    }

    private void CreateStartRoom() {
        startRoomInstance = Instantiate(startRoom, transform, false);
        startRoomInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void AddWrongDoors() {

    }

}
