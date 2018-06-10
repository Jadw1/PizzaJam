using UnityEngine;

public class RoomController : MonoBehaviour {
	public Door[] doors;
    public int entryDoorIndex = 0;
    public int exitDoorIndex = 0;
    public int roomIndex;

    public Door entryDoor {
        get {
            if (doors.Length == 0) {
                GetDoors();
            }
            return doors[entryDoorIndex]; }
    }
    public Door exitDoor {
        get {
            if(doors.Length == 0) {
                GetDoors();
            }

            return doors[exitDoorIndex]; }
    }

    private void GetDoors() {
        doors = transform.GetComponentsInChildren<Door>();
        Debug.Log("Getting doors. Amount " + doors.Length + "    " + gameObject.name);
    }

    private void Awake() {
        GetDoors();
        if(gameObject.tag != "StartRoom" && gameObject.tag != "EndRoom") {
            entryDoorIndex = Random.Range(0, doors.Length);
            exitDoorIndex = Random.Range(0, doors.Length);
            while(entryDoorIndex == exitDoorIndex) {
                exitDoorIndex = Random.Range(0, doors.Length);
            }
        }
        else {
            entryDoorIndex = exitDoorIndex = 0;
        }
    }

    public void DeactivateDoors(int index) {
        roomIndex = index;

        for(int i = 0; i < doors.Length; i++) {
            if (i == entryDoorIndex || i == exitDoorIndex) {
                continue;
            }
            
            doors[i].Deactivate();
        }
    }

	public void RandomizeConnections(RoomTower tower) {
		foreach (Door door in doors) {
			float chance = Random.Range(0.0f, 100.0f);

			if (chance < 25.0f) {
				if (door.symmetricDoor != null) return;

				door.Activate();

				if (chance < 2.5f) {
					door.symmetricDoor = exitDoor;
				} else if (chance < 5.0f) {
					door.symmetricDoor = entryDoor;
				} else if (chance < 15.0f) {
					door.symmetricDoor = tower.rooms[Random.Range(roomIndex, tower.rooms.Length)].GetComponent<RoomController>().entryDoor;
				} else {
					door.symmetricDoor = tower.rooms[tower.rooms.Length - 1].GetComponent<RoomController>().entryDoor;
				}
			}
		}
	}
}
