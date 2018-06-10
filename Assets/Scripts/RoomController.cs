using UnityEngine;

public class RoomController : MonoBehaviour {
	public Door[] doors;
    public int entryDoorIndex;
    public int exitDoorIndex;
    public int roomIndex;

    public Door entryDoor {
        get { return doors[entryDoorIndex]; }
    }
    public Door exitDoor {
        get { return doors[exitDoorIndex]; }
    }


    private void Awake() {
        doors = transform.GetComponentsInChildren<Door>();
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
        roomIndex = index + 1;

        for(int i = 0; i < doors.Length; i++) {
            if (i == entryDoorIndex || i == exitDoorIndex) {
                continue;
            }
            
            doors[i].Deactivate();
        }
    }

	public void RandomizeConnections(RoomTower tower) {
		int left = 3;

		while (left > 0) {
			float chance = Random.Range(0.0f, 100.0f);

			Door door = doors[Random.Range(0, doors.Length)];

			if (door.symmetricDoor != null) continue;
			left--;

			if (door.symmetricDoor != null) return;

			door.Activate();

			if (chance < 25f) {
				door.symmetricDoor = exitDoor;
			} else if (chance < 45f) {
				door.symmetricDoor = entryDoor;
			} else if (chance < 75.0f) {
				door.symmetricDoor = tower.rooms[Random.Range(roomIndex, tower.rooms.Length)].GetComponent<RoomController>().entryDoor;
			} else {
				door.symmetricDoor = tower.rooms[tower.rooms.Length - 1].GetComponent<RoomController>().entryDoor;
			}
		}
	}
}
