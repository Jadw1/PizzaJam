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
        roomIndex = index;

        for(int i = 0; i < doors.Length; i++) {
            if (i == entryDoorIndex || i == exitDoorIndex) {
                continue;
            }
            
            doors[i].Deactivate();
        }
    }

	public void RandomizeConnections(RoomController lastRoom) {
		foreach (Door door in doors) {
			float chance = Random.Range(0.0f, 100.0f);

			if (chance < 25.0f) {
				door.Activate();

				if (chance < 2.5f) {
					door.symmetricDoor = exitDoor;
				} else if (chance < 5.0f) {
					door.symmetricDoor = entryDoor;
				} else {
					door.symmetricDoor = lastRoom.entryDoor;
				}
			}
		}
	}
}
